using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Categories;
using Services.Exceptions;
using Services.Extensions;
using Services.IServies.Categories;
using System.Linq.Expressions;

namespace Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepositoryAsync<Category> categoryRepository;
        private readonly IMapper mapper;
        public CategoryService(IGenericRepositoryAsync<Category> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async ValueTask<CategoryForViewDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDTO)
        {
            var alreadycategory = await categoryRepository.GetAsync(c => c.Content == categoryForCreationDTO.Content);

            if (alreadycategory != null)
                throw new BelissimoCloneWPFException(400, "Category with such categoryname already exist");

            var category = await categoryRepository.CreateAsync(mapper.Map<Category>(categoryForCreationDTO));

            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryForViewDTO>(category);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await categoryRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(404, "Category Not Found");

            await categoryRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<CategoryForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Category, bool>> expression = null)
        {
            var categories = categoryRepository.GetAllAsync(expression: expression, isTracking: false,includes:new string[] {"Foods"});

            return mapper.Map<IEnumerable<CategoryForViewDTO>>(await categories.ToPagedList(@params).ToListAsync());      
        }

        public async ValueTask<CategoryForViewDTO> GetAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await categoryRepository.GetAsync(expression);

            if (category == null)
                throw new BelissimoCloneWPFException(404, "Category Not found");

            return mapper.Map<CategoryForViewDTO>(category);
        }

        public async ValueTask<CategoryForViewDTO> UpdateAsync(int id, CategoryForUpdateDTO categoryForUpdateDTO)
        {
            var categoryData = await categoryRepository.GetAsync(c => c.Id == id);

            if (categoryData == null)
                throw new BelissimoCloneWPFException(404, "Category Not Found");

            categoryData = categoryRepository.Update(mapper.Map(categoryForUpdateDTO, categoryData));

            await categoryRepository.SaveChangesAsync();

            return mapper.Map<CategoryForViewDTO>(categoryData);
        }
    }
}
