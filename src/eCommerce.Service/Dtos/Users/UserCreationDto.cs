using eCommerce.Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.Dtos.Users
{
    public class UserCreationDto
    {
        [Required, StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required, StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public decimal Balance { get; set; }
        
        [Required]
        public string Password { get; set; }

        public CreditCard CreditCard { get; set; } = null;


        public AddressCreationDto Address { get; set; } = null;
    }
}
