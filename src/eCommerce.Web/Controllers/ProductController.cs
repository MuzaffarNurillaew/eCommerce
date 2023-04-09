using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
