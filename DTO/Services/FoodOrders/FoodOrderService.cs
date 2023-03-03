using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.FoodOrders;
using Services.Exceptions;
using Services.Extentions;
using Services.IServies.FoodOrders;
using Services.IServies.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.FoodOrders
{
    public class FoodOrderService : IFoodOrderService
    {
        private readonly IGenericRepositoryAsync<FoodOrder> foodOrdersRepository;

        private readonly IMapper mapper;

        public FoodOrderService(IGenericRepositoryAsync<FoodOrder> foodOrdersRepository, IMapper mapper)
        {
            this.foodOrdersRepository = foodOrdersRepository;
            this.mapper = mapper;
        }

        public async ValueTask<FoodOrderForViewDTO> CreateAsync(FoodOrderForCreationDTO foodOrderForCreationDTO)
        {
            var alreadyfoodOrder = await foodOrdersRepository.GetAsync(c=>c.Count>=foodOrderForCreationDTO.Count);

            if (alreadyfoodOrder != null)
                throw new BelissimoCloneWPFException(400, "FoodOrder with such foodOrdername already exist");

            var foodOrder=await foodOrdersRepository.CreateAsync(mapper.Map<FoodOrder>(foodOrderForCreationDTO));

            await foodOrdersRepository.SaveChangesAsync();

            return mapper.Map<FoodOrderForViewDTO>(foodOrder);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
           var isDelete = await foodOrdersRepository.DeleteAsync(c=>c.Id==id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(404, "FoodOrder Not Delete");

            await foodOrdersRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<FoodOrderForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<FoodOrder, bool>> expression = null)
        {
            var foodOrders = foodOrdersRepository.GetAllAsync(expression: expression, isTracking: false);

            if (foodOrders == null)
                throw new BelissimoCloneWPFException(404, "FoodOrders Not Found");

            return mapper.Map<IEnumerable<FoodOrderForViewDTO>>(await foodOrders.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<FoodOrderForViewDTO> GetAsync(Expression<Func<FoodOrder, bool>> expression)
        {
            var foodOrder = await foodOrdersRepository.GetAsync(expression);

            if (foodOrder == null)
                throw new BelissimoCloneWPFException(404, "FoodOrder Not Found");

            return mapper.Map<FoodOrderForViewDTO>(foodOrder);
        }

        public async ValueTask<FoodOrderForViewDTO> UpdateAsync(int id, FoodOrderForUpdateDTO foodOrderForUpdateDTO)
        {
            var foodOrderData = await foodOrdersRepository.GetAsync(c => c.Id == id);

            if (foodOrderData == null)
                throw new BelissimoCloneWPFException(404, "FoodOrder Not Update");

            foodOrderData = foodOrdersRepository.Update(mapper.Map(foodOrderForUpdateDTO, foodOrderData));

            await foodOrdersRepository.SaveChangesAsync();

            return mapper.Map<FoodOrderForViewDTO>(foodOrderData);
        }
    }
}
