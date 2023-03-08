using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Categories
{
    public class CategoryForUpdateDTO
    {
        [Required]
        public string Content { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
