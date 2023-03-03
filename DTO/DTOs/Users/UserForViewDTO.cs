using Domian.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Users
{
    public class UserForViewDTO
    {
        public string Name { get; set; }
        public string PhoneNumer { get; set; }
    }
}
