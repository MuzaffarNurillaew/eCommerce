using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Users;

namespace eCommerce.Domain.Entities
{
    public class Payment : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public decimal TotalPayment { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
