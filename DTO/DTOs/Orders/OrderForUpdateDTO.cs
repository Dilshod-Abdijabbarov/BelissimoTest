using Domian.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Orders
{
    public class OrderForUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        [Required]
        public bool IsPayed { get; set; }
        [Required]
        public OrderType OrderType { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public int BasketId { get; set; }
        [Required]
        public int BranchId { get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
