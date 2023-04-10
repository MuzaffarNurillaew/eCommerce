using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
