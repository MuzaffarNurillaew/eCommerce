using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities
{
    public class CreditCard : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public string Number { get; set; }
        public int SecurityNumber { get; set; }
    }
}
