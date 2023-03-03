using Domian.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class Food : Auditable
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
       
    }
}
