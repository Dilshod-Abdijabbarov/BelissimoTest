using Domian.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Categories;
using Services.IServies.Categories;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromQuery] int id) =>
            Ok(await categoryService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll"),Authorize(Roles = CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> GetAll([FromQuery]PaginationParams @params)=>
            Ok(await categoryService.GetAllAsync(@params));

        [HttpPost,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody]CategoryForCreationDTO creationDTO)=>
            Ok(await categoryService.CreateAsync(creationDTO));

        [HttpPut,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery]int id, [FromBody]CategoryForUpdateDTO updateDTO)=>
            Ok(await categoryService.UpdateAsync(id, updateDTO));

        [HttpDelete,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await categoryService.DeleteAsync(id));
    }
}
