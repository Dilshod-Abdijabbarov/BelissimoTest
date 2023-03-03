using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.FoodOrders
{
    public class FoodOrderForUpdateDTO
    {
        [Required]
        public int Count { get; set; }
        [Required]
        public int FoodId { get; set; }
        [Required]
        public int BasketId { get; set; }
    }
}
