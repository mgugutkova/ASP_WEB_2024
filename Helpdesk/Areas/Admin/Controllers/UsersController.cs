using Helpdesk.Core.Enumeration;
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
        public async Task<IActionResult> AllUsers()  // не се ползва това действие
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
                 query.DirId,
                 query.CurrentPage,
                 query.UsersPerPage);

          var users = await userService.AllUsersAsync();

           // query.TotalUsersCount = model.TotalUsersCount;
            query.DirId = model.DirId;              
            query.TotalUsersCount = users.Count(); 
            query.FoundUsersCount = model.FoundUsersCount;
            query.UsersPerPage = model.UsersPerPage;
            query.UsersListAll = model.UsersLists;
            query.DirectoratesList = await directoratesService.AllDirectoratesAsync();
            query.SortItem = model.SortItem;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userId,
            int currentPage = 1,
            Status sortItem = Status.Active,
            int dirId = 0)
        {
            var model = await userService.GetUserByIdAsync(userId);

            if (model == null)
            {
                return NotFound();
            }

            ViewBag.CurrentPage = currentPage; // ще го използваме при POST

            ViewBag.SortItem = sortItem; // ще го използваме при POST
                                         
            ViewBag.DirId = dirId; // ще го използваме при POST         

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UpdateUserViewModel model,
            int currentPage = 1,
            Status sortItem = Status.Active,
            int dirId = 0)
        {
           
                if (!ModelState.IsValid)
                {
                    ViewBag.CurrentPage = currentPage;
                    ViewBag.SortItem = sortItem;
                    ViewBag.DirId = dirId;
                    model.DirectoratesList = await directoratesService.AllDirectoratesAsync();

                return View(model);
                }
            

            var id = model.UserId;

            await userService.EditUserByIdAsync(model.UserId, model);

            TempData["SuccessMessage"] = "User edited successfully!";

            // return RedirectToAction("SearchFormQuery");
            // Пренасочване към SearchFormQuery с текущата страница и текущия сортиращ елемент
            return RedirectToAction("SearchFormQuery", new {
                currentPage = currentPage,
                sortItem = sortItem,
                dirId = dirId
            });
        }
    }
}
