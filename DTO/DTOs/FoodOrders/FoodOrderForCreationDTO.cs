using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.FoodOrders
{
    public class FoodOrderForCreationDTO
    {
        [Required]
        public int Count { get; set; }
        [Required]
        public int FoodId { get; set; }
        [Required]
        public int BasketId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
