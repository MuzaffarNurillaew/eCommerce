using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View("Index","_UserLayout");
        }
    }
}
