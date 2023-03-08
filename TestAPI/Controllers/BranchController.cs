using Domian.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Branchies;
using Services.IServies.Branchies;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }

        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromRoute] int id)=>
            Ok(await branchService.GetAsync(c => c.Id == id));
        
        [HttpGet("GetAll"),Authorize(Roles =CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> GetAll([FromQuery]PaginationParams @params)=>  
            Ok(await branchService.GetAllAsync(@params));      

        [HttpPost,Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody]BranchForCreationDTO branch)=>
            Ok(await branchService.CreateAsync(branch));
        
        [HttpPut,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery]int id,
                     [FromBody]BranchForUpdateDTO forUpdateDTO)=>
            Ok(await branchService.UpdateAsync(id, forUpdateDTO));        

        [HttpDelete,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery] int id)=>
            Ok(await branchService.DeleteAsync(id));      
    }
}
