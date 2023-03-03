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
        public string Name { get; set; }
        [MaxLength(20)]
        public string PhoneNumer { get; set; }
    }
}
