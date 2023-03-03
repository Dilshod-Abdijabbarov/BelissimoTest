using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Branchies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
