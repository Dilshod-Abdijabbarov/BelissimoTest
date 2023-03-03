using Domian.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Entities
{
    public class FoodOrder : Auditable
    {
        public int Count { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int BasketId { get; set; }
        public Basket Baskets { get; set; }
    }
}
