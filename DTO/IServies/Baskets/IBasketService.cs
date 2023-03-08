using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Baskets;
using System.Linq.Expressions;

namespace Services.IServies.Baskets
{
    public interface IBasketService
    {
        ValueTask<BasketForViewDTO> CreateAsync(BasketForCreationDTO basketForCreationDTO);

        ValueTask<BasketForViewDTO> UpdateAsync(int id,BasketForUpdateDTO basketForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<BasketForViewDTO> GetAsync(Expression<Func<Basket,bool>> expression);

        ValueTask<IEnumerable<BasketForViewDTO>> GetAllAsync(PaginationParams @params,Expression<Func<Basket,bool>> expression = null);
    }
}
