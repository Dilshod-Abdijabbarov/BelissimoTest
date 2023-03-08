using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Attachments
{
    public class AttachmentForCreationDTO
    {
        [Required ]
        public string FullPath { get; set; }
        [Required]
        public Stream File { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
