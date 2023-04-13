using eCommerce.Service.Dtos.Users;
using eCommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserService userService;

        public RegistrationController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult SignUp()
        {
            
            return View("SignUp");
        }
        public IActionResult SignIn()
        {
            return View("SignIn");
        }
        public async Task<IActionResult> DoSignUp(UserCreationDto userCreationDto)
        {
            try
            {
                var service = await this.userService.CreateAsync(userCreationDto);
                return RedirectToAction("SignIn", "Registration");
            }
            catch
            {
                return RedirectToAction("UserExists", "Error", new { area = "" });
            }
            
        }
        public async Task<IActionResult> DoSignIn(string username,string password)
        {
            try
            {
                var result = await this.userService.GetAsync(x => x.UserName == username && x.Password == password);
                return RedirectToAction("Feed", "User", new {id = result.Id });
            }
            catch
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
        }
             
    }
}
