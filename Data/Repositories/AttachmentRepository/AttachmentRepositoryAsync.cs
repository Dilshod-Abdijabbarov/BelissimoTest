using DatabaseContext.Data;
using Domian.Entities;
using IRepository.IAttachmentRepository;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Repositories.AttachmentRepository
{
    public class AttachmentRepositoryAsync : GenericRepositoryAsync<Attachment>,IAttachmentRepositoryAsync
    {
        public AttachmentRepositoryAsync(BelissimoDbContext dbContext) : base(dbContext)
        {

        }
    }
}
