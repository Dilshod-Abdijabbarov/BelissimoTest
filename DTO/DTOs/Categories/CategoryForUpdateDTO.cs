using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Categories
{
    public class CategoryForUpdateDTO
    {
        [Required]
        public string Content { get; set; }
    }
}
