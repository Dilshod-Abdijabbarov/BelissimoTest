using Domian.Entities;
using Services.DTOs.FoodOrders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Baskets
{
    public class BasketForViewDTO
    {
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public ICollection<FoodOrderForViewDTO> FoodOrders { get; set; }
    }
}
