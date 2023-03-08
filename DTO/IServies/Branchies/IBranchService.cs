using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Branchies;
using System.Linq.Expressions;

namespace Services.IServies.Branchies
{
    public interface IBranchService
    {
        ValueTask<BranchForViewDTO> CreateAsync(BranchForCreationDTO branchForCreationDTO);

        ValueTask<BranchForViewDTO> UpdateAsync(int id,BranchForUpdateDTO branchForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression);

        ValueTask<IEnumerable<BranchForViewDTO>> GetAllAsync(PaginationParams @params,
            Expression<Func<Branch, bool>> expression =null);
    }
}
