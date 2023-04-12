using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Enums;

namespace eCommerce.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public UserRole Role { get; set; } = UserRole.User;
        public string Password { get; set; }

        public long? AddressId { get; set; }
        public Address Address { get; set; }

        public long? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}
