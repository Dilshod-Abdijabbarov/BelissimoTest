
using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Attachments;
using Services.Exceptions;
using Services.Extensions;
using Services.IServies.Attachments;
using System.Linq.Expressions;


namespace Services.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {

        private readonly IGenericRepositoryAsync<Attachment> attachmentRepository;

        private readonly IMapper mapper;

        public AttachmentService(IGenericRepositoryAsync<Attachment> attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }

        public async ValueTask<AttachmentForViewDTO> CreateAsync(AttachmentForCreationDTO attachmentForCreationDTO)
        {
           var alreadyattachment = await attachmentRepository.GetAsync(c=>c.FullPath == attachmentForCreationDTO.FullPath);

            if (alreadyattachment != null)
                throw new BelissimoCloneWPFException(400, "Attachment with such attachmentname already exist");

            var attachment = await attachmentRepository.CreateAsync(mapper.Map<Attachment>(attachmentForCreationDTO));

            await attachmentRepository.SaveChangesAsync();

            return mapper.Map<AttachmentForViewDTO>(attachment);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await attachmentRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new BelissimoCloneWPFException(404, "Attachment Not Delete");

            await attachmentRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<AttachmentForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<Attachment, bool>> expression = null)
        {
           var attachments= attachmentRepository.GetAllAsync(expression: expression,isTracking: false);

            if (attachments == null)
                throw new BelissimoCloneWPFException(404, "Attachment Not Found");

            return mapper.Map<IEnumerable<AttachmentForViewDTO>>(await attachments.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<AttachmentForViewDTO> GetAsync(Expression<Func<Attachment, bool>> expression)
        {
            var attachment = await attachmentRepository.GetAsync(expression);

            if (attachment == null)
                throw new BelissimoCloneWPFException(404, "Attachment Not Found");

            return mapper.Map<AttachmentForViewDTO>(attachment);
        }

        public async ValueTask<AttachmentForViewDTO> UpdateAsync(int id, AttachmentForUpdateDTO attachmentForUpdateDTO)
        {
            var attachmentData = await attachmentRepository.GetAsync(c=>c.Id==id);

            if (attachmentData == null)
                throw new BelissimoCloneWPFException(404, "Attachment Not Found");

            attachmentData = attachmentRepository.Update(mapper.Map(attachmentForUpdateDTO,attachmentData));

            await attachmentRepository.SaveChangesAsync();

            return mapper.Map<AttachmentForViewDTO>(attachmentData);
        }
    }
}
