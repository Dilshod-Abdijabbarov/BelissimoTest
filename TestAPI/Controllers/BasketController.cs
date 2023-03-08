using DatabaseContext;
using Domian.Configurations;
using Domian.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Services.DTOs.Baskets;
using Services.IServies.Baskets;
using System.Linq;
using System.Linq.Expressions;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }
        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromRoute]int id)=>
            Ok(await basketService.GetAsync(c=>c.Id==id));

        [HttpGet("GetAll"),Authorize(Roles = CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)=>
            Ok(await basketService.GetAllAsync(@params));
        
        [HttpPost,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody]BasketForCreationDTO forCreationDTO)=>
            Ok(await basketService.CreateAsync(forCreationDTO));

        [HttpPut,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery]int id, [FromBody]BasketForUpdateDTO forUpdateDTO)=>
            Ok(await basketService.UpdateAsync(id, forUpdateDTO));

        [HttpDelete,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await basketService.DeleteAsync(id));
    }
}
