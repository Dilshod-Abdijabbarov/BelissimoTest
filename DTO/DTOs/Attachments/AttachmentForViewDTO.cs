using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Attachments
{
    public class AttachmentForViewDTO
    {
        public string FullPath { get; set; }
        public Stream File { get; set; }
    }
}
