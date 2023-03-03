using Domian.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Orders;
using Services.IServies.Orders;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute]int id)=>
            Ok(await orderService.GetAsync(c=>c.Id==id));
        
        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll([FromQuery]PaginationParams @params)=>
            Ok(await orderService.GetAllAsync(@params));
        
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody]OrderForCreationDTO creationDTO)=>      
             Ok(await orderService.CreateAsync(creationDTO));
        
        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery]int id, 
                     [FromBody]OrderForUpdateDTO updateDTO)=>       
            Ok(await orderService.UpdateAsync(id, updateDTO));      

        [HttpDelete]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await orderService.DeleteAsync(id));        
    }
}
