using System.ComponentModel.DataAnnotations;

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
