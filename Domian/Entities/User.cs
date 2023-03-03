using Domian.Commons;
using Domian.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class User : Auditable
    {
        public string Name { get; set; }
        public string PhoneNumer { get; set; }
        public UserRole Role { get; set; }
        
    }
  
}
