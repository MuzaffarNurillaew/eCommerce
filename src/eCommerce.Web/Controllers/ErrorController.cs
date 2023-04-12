using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult UserExists()
        {
            return View();
        }
    }
}
