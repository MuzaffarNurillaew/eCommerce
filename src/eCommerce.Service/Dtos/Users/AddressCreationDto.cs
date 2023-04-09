namespace eCommerce.Service.Dtos.Users
{
    public class AddressCreationDto
    {
        public string Planet { get; set; } = "Earth";
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
    }
}
