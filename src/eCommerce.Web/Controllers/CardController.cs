using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class CardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
