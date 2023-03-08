using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Users
{
    public class UserForUpdateDTO
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string PhoneNumer { get; set; }

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
