using Domian.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Foods;
using Services.IServies.Foods;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService foodService;

        public FoodController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
            Ok(await foodService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params) =>
            Ok(await foodService.GetAllAsync(@params));

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] FoodForCreationDTO forCreationDTO)=>
            Ok(await foodService.CreateAsync(forCreationDTO));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery]int id, 
                     [FromBody]FoodForUpdateDTO forUpdateDTO)=>
            Ok(await foodService.UpdateAsync(id, forUpdateDTO));

        [HttpDelete]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await foodService.DeleteAsync(id));
    }
}
