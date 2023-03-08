using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Users
{
    public class UserAuthInfoDTO
    {
        public UserForViewDTO UserDetails { get; set; }
        public string Token { get; set; }
    }
}
