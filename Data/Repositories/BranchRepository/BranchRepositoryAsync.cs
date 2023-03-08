using DatabaseContext.Data;
using Domian.Entities;
using IRepository.IBranchRepository;
using Repository.GenericRepository;

namespace Repository.BranchRepository
{
    public class BranchRepositoryAsync : GenericRepositoryAsync<Branch>,IBranchRepositoryAsync
    {
        public BranchRepositoryAsync(BelissimoDbContext dbContext):base(dbContext)
        {

        }
    }
}
