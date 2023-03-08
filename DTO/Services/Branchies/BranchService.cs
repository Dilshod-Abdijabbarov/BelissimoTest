using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Branchies;
using Services.Exceptions;
using Services.Extensions;
using Services.IServies.Branchies;
using System.Linq.Expressions;

namespace Services.Services.Branchies
{
    public class BranchService : IBranchService
    {
        private readonly IGenericRepositoryAsync<Branch> branchRepository;

        private readonly IMapper mapper;

        public BranchService(IGenericRepositoryAsync<Branch> branchRepository, IMapper mapper)
        {
            this.branchRepository = branchRepository;
            this.mapper = mapper;
        }

        public async ValueTask<BranchForViewDTO> CreateAsync(BranchForCreationDTO branchForCreationDTO)
        {
           var alreadyBranch = await branchRepository.GetAsync(c=>c.Name==branchForCreationDTO.Name);

            if (alreadyBranch != null)
                throw new BelissimoCloneWPFException(400, "Branch with such branchname already exist");

            var branch = await branchRepository.CreateAsync(mapper.Map<Branch>(branchForCreationDTO));

            await branchRepository.SaveChangesAsync();

            return mapper.Map<BranchForViewDTO>(branch);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await branchRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(404, "Branch Not Delete");

            await branchRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<BranchForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Branch, bool>> expression = null)
        {
            var branchies = branchRepository.GetAllAsync(expression: expression,isTracking: false);

            return mapper.Map<IEnumerable<BranchForViewDTO>>(await branchies.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<BranchForViewDTO> GetAsync(Expression<Func<Branch, bool>> expression)
        {
           var branch = await branchRepository.GetAsync(expression);

            if (branch == null)
                throw new BelissimoCloneWPFException(404, "Branch Not Found");

            return mapper.Map<BranchForViewDTO>(branch);
        }

        public async ValueTask<BranchForViewDTO> UpdateAsync(int id,BranchForUpdateDTO branchForUpdateDTO)
        {
            var branchData = await branchRepository.GetAsync(c => c.Id == id);

            if (branchData == null)
                throw new BelissimoCloneWPFException(404, "Branch Not Update");

            branchData = branchRepository.Update(mapper.Map(branchForUpdateDTO, branchData));

            await branchRepository.SaveChangesAsync();

            return mapper.Map<BranchForViewDTO>(branchData);
        }
    }
}
