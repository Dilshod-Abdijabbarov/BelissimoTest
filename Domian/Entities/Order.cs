using Domian.Commons;
using Domian.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class Order : Auditable
    {
        public string Location { get; set; }
        public bool IsPayed { get; set; }
        public OrderType OrderType { get; set; }
        public PaymentType PaymentType { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }       
       
    }
    
}
