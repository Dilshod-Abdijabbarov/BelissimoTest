using DatabaseContext;
using Domian.Entities;
using IRepository.IFoodRepository;
using Repository.GenericRepository;

namespace Repository.FoodRepository
{
    public class FoodRepositoryAsync : GenericRepositoryAsync<Food>,IFoodRepositoryAsync
    {
        public FoodRepositoryAsync(BelissimoDbContext dbContext):base(dbContext)
        {

        }
    }
}
