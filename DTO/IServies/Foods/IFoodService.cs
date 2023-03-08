using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Foods;
using System.Linq.Expressions;

namespace Services.IServies.Foods
{
    public interface IFoodService
    {
        ValueTask<FoodForViewDTO> CreateAsync(FoodForCreationDTO foodForCreationDTO);

        ValueTask<FoodForViewDTO> UpdateAsync(int id,FoodForUpdateDTO foodForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<FoodForViewDTO> GetAsync(Expression<Func<Food,bool>> expression);

        ValueTask<IEnumerable<FoodForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<Food,bool>> expression = null);
    }
}
