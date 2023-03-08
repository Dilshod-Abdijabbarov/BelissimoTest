using Domian.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Orders;
using Services.IServies.Orders;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromRoute]int id)=>
            Ok(await orderService.GetAsync(c=>c.Id==id));
        
        [HttpGet("GetAll"),Authorize(Roles =CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> GetAll([FromQuery]PaginationParams @params)=>
            Ok(await orderService.GetAllAsync(@params));
        
        [HttpPost,Authorize(Roles =CustomRoles.USER_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody]OrderForCreationDTO creationDTO)=>      
             Ok(await orderService.CreateAsync(creationDTO));
        
        [HttpPut,Authorize(Roles =CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery]int id, 
                     [FromBody]OrderForUpdateDTO updateDTO)=>       
            Ok(await orderService.UpdateAsync(id, updateDTO));      

        [HttpDelete,Authorize(Roles =CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await orderService.DeleteAsync(id));        
    }
}
