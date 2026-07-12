using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fondacia.Controllers
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
    }
}
