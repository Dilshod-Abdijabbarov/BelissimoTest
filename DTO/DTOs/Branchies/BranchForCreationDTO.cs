﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Branchies
{
    public class BranchForCreationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Operator { get; set; }
        [Required]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
