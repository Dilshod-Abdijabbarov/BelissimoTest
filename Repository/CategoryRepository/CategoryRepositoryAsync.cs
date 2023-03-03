using DatabaseContext;
using Domian.Entities;
using IRepository.ICategoryRepository;
using Repository.GenericRepository;

namespace Repository.CategoryRepository
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>,ICategoryRepositoryAsync
    {
        public CategoryRepositoryAsync(BelissimoDbContext dbContext):base(dbContext)
        {

        }
    }
}
