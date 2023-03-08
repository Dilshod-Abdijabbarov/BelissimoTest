using Domian.Configurations;
using Domian.Entities;
using Domian.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Users;
using Services.IServies.Users;
using System.Linq.Expressions;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
           Ok(await userService.GetAsync(c => c.Id == id));


        [HttpGet("GetAll"),Authorize(Roles =CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params) =>
           Ok(await userService.GetAllAsync(@params));


        [HttpPost,Authorize(Roles =CustomRoles.USER_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody] UserForCreationDTO user) =>
            Ok(await userService.CreateAsync(user));


        [HttpPut,Authorize(Roles =CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                     [FromBody] UserForUpdateDTO user) =>
            Ok(await userService.UpdateAsync(id, user));


        [HttpDelete,Authorize(Roles =CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery] int id) =>
            Ok(await userService.DeleteAsync(id));


        [HttpPut("ChangePassword"),Authorize(Roles =CustomRoles.USER_ROLE)]
        public async ValueTask<IActionResult> ChangePassword([FromBody]UserForChangePasswordDTO changePassword)=>
            Ok(await userService.ChangePasswordAsync(changePassword));
            
    }
}
