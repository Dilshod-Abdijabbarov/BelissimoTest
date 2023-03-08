using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Categories
{
    public class CategoryForCreationDTO
    {
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
