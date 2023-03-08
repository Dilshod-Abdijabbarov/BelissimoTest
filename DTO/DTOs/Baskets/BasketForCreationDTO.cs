using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Baskets
{
    public class BasketForCreationDTO
    {
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
