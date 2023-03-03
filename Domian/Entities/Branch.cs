using Domian.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class Branch : Auditable
    {
        public string Name { get; set; }
        public string Operator { get; set; }
        public string Location { get; set; }
    }
}
