using Domian.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Categories;
using Services.IServies.Categories;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromQuery] int id) =>
            Ok(await categoryService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll([FromQuery]PaginationParams @params)=>
            Ok(await categoryService.GetAllAsync(@params));

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody]CategoryForCreationDTO creationDTO)=>
            Ok(await categoryService.CreateAsync(creationDTO));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery]int id, [FromBody]CategoryForUpdateDTO updateDTO)=>
            Ok(await categoryService.UpdateAsync(id, updateDTO));

        [HttpDelete]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await categoryService.DeleteAsync(id));
    }
}
