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
            var userName = await userManager.FindByNameAsync(HttpContext.User?.Identity?.Name != null ? HttpContext.User.Identity.Name : string.Empty);

            if (userName == null)
            {
                return View("BadRequest");
            }
            var model = new UpdateUserViewModel()
            {
                Id = userName.Id,
                Email = userName.Email ?? string.Empty,
                FirstName = userName.FirstName,
                LastName = userName.LastName
            };

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

            var userName = await userManager.FindByIdAsync(model.Id);

            userName.FirstName = model.FirstName;
            userName.LastName = model.LastName;
            userName.Email = model.Email;

            await userManager.UpdateAsync(userName);

            return RedirectToAction("Index", "Home");
        }
    }
}
