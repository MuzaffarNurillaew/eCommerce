using eCommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Feed(int id)
        {
         
            var feedData = await this.userService.GetAsync(x => x.Id == id);
            return View(feedData);
        }
    }
}
