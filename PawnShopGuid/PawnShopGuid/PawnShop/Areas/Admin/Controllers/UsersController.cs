using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Constants;
using PawnShop.Core.Interfaces;

namespace PawnShop.Areas.Admin.Controllers
{
    public class UsersController : AdminBaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await userService.AllAsync();

            return View(model);
        }       
    }
}
