using Domian.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Baskets;
using Services.IServies.Baskets;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute]int id)=>
            Ok(await basketService.GetAsync(c=>c.Id==id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params) =>
            Ok(await basketService.GetAllAsync(@params));

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody]BasketForCreationDTO forCreationDTO)=>
            Ok(await basketService.CreateAsync(forCreationDTO));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery]int id, [FromBody]BasketForUpdateDTO forUpdateDTO)=>
            Ok(await basketService.UpdateAsync(id, forUpdateDTO));

        [HttpDelete]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await basketService.DeleteAsync(id));
    }
}
