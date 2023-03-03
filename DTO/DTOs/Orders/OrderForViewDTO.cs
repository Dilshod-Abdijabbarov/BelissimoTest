using Domian.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Orders
{
    public class OrderForViewDTO
    {
        public string Location { get; set; }
        public bool IsPayed { get; set; }
        public OrderType OrderType { get; set; }
        public PaymentType PaymentType { get; set; }
        public int BasketId { get; set; }
        public int CourierId { get; set; }
        public int BnachId { get; set; }
    }
}
