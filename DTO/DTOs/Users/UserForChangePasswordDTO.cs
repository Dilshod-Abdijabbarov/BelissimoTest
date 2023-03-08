using Services.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Users
{
    public class UserForChangePasswordDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required, UserPassword]
        public string NewPassword { get; set; }
    }
}
