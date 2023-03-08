using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Orders;
using Services.Exceptions;
using Services.Extensions;
using Services.IServies.Orders;
using System.Linq.Expressions;

namespace Services.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepositoryAsync<Order> orderRepository;

        private readonly IMapper mapper;

        public OrderService(IGenericRepositoryAsync<Order> orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async ValueTask<OrderForViewDTO> CreateAsync(OrderForCreationDTO orderForCreationDTO)
        {
           // var alreadyOrder = await orderRepository.GetAsync(x=>x.);

            var order = await orderRepository.CreateAsync(mapper.Map<Order>(orderForCreationDTO));

            await orderRepository.SaveChangesAsync();

            return mapper.Map<OrderForViewDTO>(order);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await orderRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(404, "Order Not Delete");

            await  orderRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<OrderForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null)
        {
            var orders = orderRepository.GetAllAsync(expression: expression, isTracking: false);

            if (orders == null)
                throw new BelissimoCloneWPFException(404, "Orders Not found");

            return mapper.Map<IEnumerable<OrderForViewDTO>>(await orders.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<OrderForViewDTO> GetAsync(Expression<Func<Order, bool>> expression)
        {
           var order = await orderRepository.GetAsync(expression);

            if (order == null)
                throw new BelissimoCloneWPFException(404, "Orders Not Fount");

            return mapper.Map<OrderForViewDTO>(order);
        }

        public async ValueTask<OrderForViewDTO> UpdateAsync(int id, OrderForUpdateDTO orderForUpdateDTO)
        {
            var orderData = await orderRepository.GetAsync(c => c.Id == id);

            if (orderData == null)
                throw new BelissimoCloneWPFException(404, "Order Not Update");

            orderData = orderRepository.Update(mapper.Map(orderForUpdateDTO, orderData));

            await orderRepository.SaveChangesAsync();

            return mapper.Map<OrderForViewDTO>(orderData);
        }
    }
}
