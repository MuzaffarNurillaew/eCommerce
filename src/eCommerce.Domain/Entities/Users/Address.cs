using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Users
{
    public class Address : Auditable
    {
        public string Planet { get; set; } = "Earth";
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }

        public User User { get; set; }
    }
}
