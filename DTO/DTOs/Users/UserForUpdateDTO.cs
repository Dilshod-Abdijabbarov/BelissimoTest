using Domian.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
