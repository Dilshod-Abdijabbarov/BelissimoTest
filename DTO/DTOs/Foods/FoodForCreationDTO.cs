﻿using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Foods
{
    public class FoodForCreationDTO
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
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
