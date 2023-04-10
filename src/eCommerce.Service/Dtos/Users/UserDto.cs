using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Domain.Entities.Orders;

namespace eCommerce.Service.Dtos.Users
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }

        public AddressDto Address { get; set; }
        public CreditCard CreditCard { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}
