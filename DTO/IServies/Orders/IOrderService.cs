using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServies.Orders
{
    public interface IOrderService
    {
        ValueTask<OrderForViewDTO> CreateAsync(OrderForCreationDTO orderForCreationDTO);

        ValueTask<OrderForViewDTO> UpdateAsync(int id,OrderForUpdateDTO orderForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<OrderForViewDTO> GetAsync(Expression<Func<Order,bool>> expression);

        ValueTask<IEnumerable<OrderForViewDTO>> GetAllAsync(PaginationParams @params,
            Expression<Func<Order,bool>> expression =null);
    }
}
