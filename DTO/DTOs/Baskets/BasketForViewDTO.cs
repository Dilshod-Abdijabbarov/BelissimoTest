using Services.DTOs.FoodOrders;

namespace Services.DTOs.Baskets
{
    public class BasketForViewDTO
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public ICollection<FoodOrderForViewDTO> FoodOrders { get; set; }
    }
}
