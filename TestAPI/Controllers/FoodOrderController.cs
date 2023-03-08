using Domian.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.FoodOrders;
using Services.DTOs.Foods;
using Services.IServies.FoodOrders;
using System.Data;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrderController : ControllerBase
    {
        private readonly IFoodOrderService foodOrderService;
        public FoodOrderController(IFoodOrderService foodOrderService)
        {
            this.foodOrderService = foodOrderService;
        }
        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
            Ok(await foodOrderService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll"),Authorize(Roles = CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params) =>
            Ok(await foodOrderService.GetAllAsync(@params));

        [HttpPost,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody] FoodOrderForCreationDTO forCreationDTO) =>
            Ok(await foodOrderService.CreateAsync(forCreationDTO));

        [HttpPut,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery]int id, 
                     [FromBody]FoodOrderForUpdateDTO orderForUpdateDTO)=>
            Ok(await foodOrderService.UpdateAsync(id, orderForUpdateDTO));

        [HttpDelete,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await foodOrderService.DeleteAsync(id));
    }
}
