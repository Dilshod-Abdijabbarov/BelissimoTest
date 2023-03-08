using Domian.Enums;

namespace Services.DTOs.Orders
{
    public class OrderForViewDTO
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public bool IsPayed { get; set; }
        public OrderType OrderType { get; set; }
        public PaymentType PaymentType { get; set; }
        public int BasketId { get; set; }
        public int BranchId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
