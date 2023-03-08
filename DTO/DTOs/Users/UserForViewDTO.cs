using Domian.Enums;

namespace Services.DTOs.Users
{
    public class UserForViewDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
    }
}
