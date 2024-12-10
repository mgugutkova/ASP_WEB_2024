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

        public async Task<IActionResult> All()
        {
            var model = await userService.AllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Forget(string userId)
        {
            bool result = await userService.Forget(userId);

            if (result)
            {
                TempData[TempDataConstants.SuccessMessage] = "User is now forgotten";
            }
            else
            {
                TempData[TempDataConstants.ErrorMessage] = "User is unforgetable";
            }

            return RedirectToAction(nameof(All));
        }
    }
}
