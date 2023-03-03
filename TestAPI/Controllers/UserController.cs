using Domian.Configurations;
using Domian.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Users;
using Services.IServies.Users;
using System.Linq.Expressions;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
           this.userService = userService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id)=>
           Ok(await userService.GetAsync(c => c.Id == id));
              
        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll([FromQuery]PaginationParams @params)=>
           Ok(await userService.GetAllAsync(@params));
        
        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] UserForCreationDTO user)=>
            Ok(await userService.CreateAsync(user));     

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                     [FromBody] UserForUpdateDTO user)=>
            Ok(await userService.UpdateAsync(id, user));

        [HttpDelete]
        public async ValueTask<IActionResult> Delete([FromQuery] int id)=>
            Ok(await userService.DeleteAsync(id));       
    }
}
