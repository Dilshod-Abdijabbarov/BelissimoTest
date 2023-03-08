using Domian.Entities;
using Services.DTOs.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Categories
{
    public class CategoryForViewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<FoodForViewDTO> Foods { get; set; }
    }
}
