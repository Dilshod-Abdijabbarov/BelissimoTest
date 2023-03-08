using DatabaseContext.Data;
using Domian.Entities;
using IRepository.IFoodOrderRepository;
using Repository.GenericRepository;

namespace Repository.FoodOrderRepository
{
    public class FoodOrderRepositoryAsync : GenericRepositoryAsync<FoodOrder>,IFoodOrderRepositoryAsync
    {
        public FoodOrderRepositoryAsync(BelissimoDbContext dbContext):base(dbContext)
        {

        }
    }
}
