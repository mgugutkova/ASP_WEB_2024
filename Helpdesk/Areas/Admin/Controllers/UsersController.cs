using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.ApplicationUser;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class UsersController : AdminBaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
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
                 query.CurrentPage,
                 query.UsersPerPage);

          var users = await userService.AllUsersAsync();

           // query.TotalUsersCount = model.TotalUsersCount;
            query.TotalUsersCount = users.Count();       
            query.UsersPerPage = model.UsersPerPage;
            query.UsersListAll = model.UsersLists;

            return View(query);
        }
    }
}
