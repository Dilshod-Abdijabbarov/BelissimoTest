using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Foods;
using Services.Exceptions;
using Services.Extensions;
using Services.IServies.Foods;
using System.Linq.Expressions;

namespace Services.Services.Foods
{
    public class FoodService : IFoodService
    {
        private readonly IGenericRepositoryAsync<Food> foodRepository;

        private readonly IMapper mapper;
        public FoodService(IGenericRepositoryAsync<Food> foodRepository,IMapper mapper)
        {
            this.foodRepository = foodRepository;
            this.mapper=mapper;
        }

        public async ValueTask<FoodForViewDTO> CreateAsync(FoodForCreationDTO foodForCreationDTO)
        {
            var alreadyfood = await foodRepository.GetAsync(c=>c.Name == foodForCreationDTO.Name);

            if (alreadyfood != null)
                throw new BelissimoCloneWPFException(400, "Food with such Foodname already exist");

            var food = await foodRepository.CreateAsync(mapper.Map<Food>(foodForCreationDTO));

            await foodRepository.SaveChangesAsync();
             
            return mapper.Map<FoodForViewDTO>(food);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await foodRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(401, "Food Not Delete");

            await foodRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<FoodForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Food, bool>> expression = null)
        {
           var foods = foodRepository.GetAllAsync(expression: expression,isTracking: false);

            if (foods == null)
                throw new BelissimoCloneWPFException(404, "Food Not fount");

            return mapper.Map<IEnumerable<FoodForViewDTO>>(await foods.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<FoodForViewDTO> GetAsync(Expression<Func<Food, bool>> expression)
        {
           var food = await foodRepository.GetAsync(expression);

            if (food == null)
                throw new BelissimoCloneWPFException(404, "Food Not found");

            return  mapper.Map<FoodForViewDTO>(food);
        }

        public async ValueTask<FoodForViewDTO> UpdateAsync(int id, FoodForUpdateDTO foodForUpdateDTO)
        {
            var foodData = await foodRepository.GetAsync(c => c.Name==foodForUpdateDTO.Name);

            if (foodData == null)
                throw new BelissimoCloneWPFException(404, "Food Not Update");

            foodData = foodRepository.Update(mapper.Map(foodForUpdateDTO, foodData));

            await foodRepository.SaveChangesAsync();

            return mapper.Map<FoodForViewDTO>(foodData);
        }
    }
}
