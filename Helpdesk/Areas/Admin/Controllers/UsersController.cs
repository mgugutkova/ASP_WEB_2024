using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.ApplicationUser;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class UsersController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IDirectoratesService directoratesService;

        public UsersController(IUserService _userService,
            IDirectoratesService _directoratesService)
        {
            userService = _userService;
            directoratesService = _directoratesService;
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var users = await userService.AllUsersAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> SearchFormQuery([FromQuery] AllUsersQueryViewModel query)
        {
            var model = await userService.AllUsersQueryAsync(
                 query.SearchItem,              
                 query.SortItem,  
               //  query.Status.Active,               // Status.Active,
                 query.dirId,
                 query.CurrentPage,
                 query.UsersPerPage);

          var users = await userService.AllUsersAsync();

           // query.TotalUsersCount = model.TotalUsersCount;
            query.dirId = model.dirId;              
            query.TotalUsersCount = users.Count(); 
            query.FoundUsersCount = model.FoundUsersCount;
            query.UsersPerPage = model.UsersPerPage;
            query.UsersListAll = model.UsersLists;
            query.DirectoratesList = await directoratesService.AllDirectoratesAsync();
            query.SortItem = model.SortItem;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId, int currentPage = 1)
        {
            var model = await userService.GetUserByIdAsync(userId);

            if (model == null)
            {
                return NotFound();
            }

            ViewBag.CurrentPage = currentPage; // ще го използваме при POST

            //  var directorates = await directoratesService.AllDirectoratesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UpdateUserViewModel model, int currentPage = 1)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var id = model.UserId;

            await userService.EditUserByIdAsync(model.UserId, model);

            TempData["SuccessMessage"] = "User edited successfully!";

            // return RedirectToAction("SearchFormQuery");
            // Пренасочване към SearchFormQuery с текущата страница
            return RedirectToAction("SearchFormQuery", new { CurrentPage = currentPage });
        }
    }
}
