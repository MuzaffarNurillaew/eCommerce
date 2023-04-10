using eCommerce.Service.Dtos.Users;
using eCommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService userService;


        public IActionResult SignUp()
        {
            return View();
        }
        public async Task<IActionResult> DoSignUp(UserCreationDto userCreationDto) 
        { 
            var service = await this.userService.CreateAsync(userCreationDto);
            return View("Index", "Product");
        }
        public IActionResult SignIn() 
        { 
            return View();
        }
    }
}
