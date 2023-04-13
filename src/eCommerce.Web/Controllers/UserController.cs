using eCommerce.Service.Dtos.Users;
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
            Response.Cookies.Append("userid", feedData.Id.ToString());
            return View(feedData);
        }
        public async Task<IActionResult> Profile()
        {
            var id = Request.Cookies["userid"];

            var feedData = await this.userService.GetAsync(x => x.Id == int.Parse(id));
            return View(feedData);
        }
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var id = Request.Cookies["userid"];
            var data = await this.userService.GetAsync(x => x.Id == int.Parse(id));
            return View(data);
        }
        public async Task<IActionResult> DoUpdate(UserUpdateDto userUpdateDto)
        {
            var id = Request.Cookies["userid"];
            await this.userService.UpdateAsync(x => x.Id == int.Parse(id), userUpdateDto);
            return RedirectToAction("Profile", "User");

        }
        public IActionResult Card()
        {
            return View();
        }


    }
}
