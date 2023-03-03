using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
