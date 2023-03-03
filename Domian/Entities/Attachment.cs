using Domian.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class Attachment : Auditable
    {
        public string FullPath { get; set; }
    }
}
