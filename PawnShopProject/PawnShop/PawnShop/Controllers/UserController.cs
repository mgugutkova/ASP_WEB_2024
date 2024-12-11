using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.User;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserService _userService, UserManager<ApplicationUser> _userManager)
        {
            userService = _userService;
            userManager = _userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId =  GetUserId();          

            var model = await userService.EditAsync(userId);

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("BadRequest");
            }

            await userService.UpdateUserAsync(model.Id, model);           

            return RedirectToAction("Index", "Home");
        }
    }
}
