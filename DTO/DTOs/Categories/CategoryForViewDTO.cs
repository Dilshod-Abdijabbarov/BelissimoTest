using Services.DTOs.Foods;

namespace Services.DTOs.Categories
{
    public class CategoryForViewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<FoodForViewDTO> Foods { get; set; }
    }
}
