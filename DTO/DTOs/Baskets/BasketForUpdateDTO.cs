using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Baskets
{
    public class BasketForUpdateDTO
    {
        [Required]
        public int UserId { get; set; }
    }
}
