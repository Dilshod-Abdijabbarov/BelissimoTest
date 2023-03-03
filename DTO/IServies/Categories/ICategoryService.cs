using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Categories;
using System.Linq.Expressions;

namespace Services.IServies.Categories
{
    public interface ICategoryService
    {
        ValueTask<CategoryForViewDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDTO);

        ValueTask<CategoryForViewDTO> UpdateAsync(int id,CategoryForUpdateDTO categoryForViewDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<CategoryForViewDTO> GetAsync(Expression<Func<Category,bool>> expression);

        ValueTask<IEnumerable<CategoryForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<Category,bool>> expression=null);
    }
}
