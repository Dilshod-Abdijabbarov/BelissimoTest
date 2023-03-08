namespace Services.DTOs.Foods
{
    public class FoodForViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public int AttachmentId { get; set; }
    }
}
