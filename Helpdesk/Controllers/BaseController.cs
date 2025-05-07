using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Helpdesk.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        //private readonly UserManager<ApplicationUser> userManager;
        //public BaseController(UserManager<ApplicationUser> _userManager)
        //{
        //    userManager = _userManager;
        //}

        [HttpGet]
        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        //[HttpGet]
        //public async Task<string> UserFullName()
        //{
        //    var userId = GetUserId();
        //    var fullName = await userManager.Users
        //        .Where(x => x.Id == userId)
        //        .Select(x => x.FirstName + " " + x.LastName)
        //        .FirstOrDefaultAsync();

        //    return fullName ?? string.Empty;     
        //}
    }
}
