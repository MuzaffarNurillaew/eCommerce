using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Users;

namespace eCommerce.Domain.Entities.Orders
{
    public class CreditCard : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public string Number { get; set; }
        public int SecurityNumber { get; set; }
    }
}
