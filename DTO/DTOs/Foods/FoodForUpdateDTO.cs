using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Foods
{
    public class FoodForUpdateDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int AttachmentId { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
