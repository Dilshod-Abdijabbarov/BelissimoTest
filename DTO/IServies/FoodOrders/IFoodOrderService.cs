using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.FoodOrders;
using System.Linq.Expressions;

namespace Services.IServies.FoodOrders
{
    public interface IFoodOrderService
    {
        ValueTask<FoodOrderForViewDTO> CreateAsync(FoodOrderForCreationDTO foodOrderForCreationDTO);

        ValueTask<FoodOrderForViewDTO> UpdateAsync(int id,FoodOrderForUpdateDTO foodOrderForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<FoodOrderForViewDTO> GetAsync(Expression<Func<FoodOrder,bool>> expression);

        ValueTask<IEnumerable<FoodOrderForViewDTO>> GetAllAsync(PaginationParams @params,Expression<Func<FoodOrder,bool>> expression = null);
    }
}
