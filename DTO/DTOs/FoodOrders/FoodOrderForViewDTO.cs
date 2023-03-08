using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.FoodOrders
{
    public class FoodOrderForViewDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int FoodId { get; set; }
        public int BasketId { get; set; }
    }
}
