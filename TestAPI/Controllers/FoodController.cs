using Domian.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Foods;
using Services.IServies.Foods;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService foodService;

        public FoodController(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
            Ok(await foodService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll"),Authorize(Roles = CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params) =>
            Ok(await foodService.GetAllAsync(@params));

        [HttpPost,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody] FoodForCreationDTO forCreationDTO)=>
            Ok(await foodService.CreateAsync(forCreationDTO));

        [HttpPut,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery]int id, 
                     [FromBody]FoodForUpdateDTO forUpdateDTO)=>
            Ok(await foodService.UpdateAsync(id, forUpdateDTO));

        [HttpDelete,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await foodService.DeleteAsync(id));
    }
}
