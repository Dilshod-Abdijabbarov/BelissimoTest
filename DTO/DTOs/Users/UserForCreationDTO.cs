﻿using Domian.Enums;
using Services.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Users
{
    public class UserForCreationDTO
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string PhoneNumer { get; set; }
        [Required]
        public string Login { get; set; }
        [Required,UserPassword]
        public string Password { get; set; }
        [Required]
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
