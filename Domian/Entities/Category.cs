using Domian.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class Category : Auditable
    {
        public string Content { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
