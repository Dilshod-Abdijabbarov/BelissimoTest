using Domian.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Attachments;
using Services.IServies.Attachments;
using TestAPI.Helpers;

namespace TestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService attachmentService;
        public AttachmentController(IAttachmentService attachmentService)
        {
            this.attachmentService = attachmentService;
        }

        [HttpGet("{id}"),Authorize(Roles =CustomRoles.ALL_ROLES)]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
            Ok(await attachmentService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll"),Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params) =>
        Ok(await attachmentService.GetAllAsync(@params));

        [HttpPost,Authorize(Roles = CustomRoles.USER_ROLE)]
        public async ValueTask<IActionResult> Create([FromBody]AttachmentForCreationDTO forCreationDTO)=>
            Ok(await attachmentService.CreateAsync(forCreationDTO));

        [HttpPut,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Update([FromQuery]int id, 
                     [FromBody]AttachmentForUpdateDTO forUpdateDTO)=>
            Ok(await attachmentService.UpdateAsync(id, forUpdateDTO));

        [HttpDelete,Authorize(Roles = CustomRoles.ADMIN_ROLE)]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await attachmentService.DeleteAsync(id));
    }
}
