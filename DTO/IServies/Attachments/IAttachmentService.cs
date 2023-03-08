using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Attachments;
using System.Linq.Expressions;

namespace Services.IServies.Attachments
{
    public interface IAttachmentService
    {
        ValueTask<AttachmentForViewDTO> CreateAsync(AttachmentForCreationDTO attachmentForCreationDTO);

        ValueTask<AttachmentForViewDTO> UpdateAsync(int id,AttachmentForUpdateDTO attachmentForUpdateDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<AttachmentForViewDTO> GetAsync(Expression<Func<Attachment,bool>> expression);

        ValueTask<IEnumerable<AttachmentForViewDTO>> GetAllAsync(PaginationParams @params,Expression<Func<Attachment,bool>> expression = null);
    }
}
