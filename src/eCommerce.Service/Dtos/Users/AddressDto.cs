using eCommerce.Domain.Entities.Users;

namespace eCommerce.Service.Dtos.Users
{
    public class AddressDto
    {
        public string Planet { get; set; } = "Earth";
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }

        public User User { get; set; }
    }
}
