using Domian.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class Basket : Auditable
    {
        public int TotalPrice { get; set; }
        public int UserId { get; set; }    
        public User User { get; set; }
        public ICollection<FoodOrder> FoodOrders { get; set; }
    }
}
