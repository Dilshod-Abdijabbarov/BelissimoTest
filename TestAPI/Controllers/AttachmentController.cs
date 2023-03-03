using Domian.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Attachments;
using Services.IServies.Attachments;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService attachmentService;
        public AttachmentController(IAttachmentService attachmentService)
        {
            this.attachmentService = attachmentService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
            Ok(await attachmentService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params) =>
        Ok(await attachmentService.GetAllAsync(@params));

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody]AttachmentForCreationDTO forCreationDTO)=>
            Ok(await attachmentService.CreateAsync(forCreationDTO));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery]int id, 
                     [FromBody]AttachmentForUpdateDTO forUpdateDTO)=>
            Ok(await attachmentService.UpdateAsync(id, forUpdateDTO));

        [HttpDelete]
        public async ValueTask<IActionResult> Delete([FromQuery]int id)=>
            Ok(await attachmentService.DeleteAsync(id));
    }
}
