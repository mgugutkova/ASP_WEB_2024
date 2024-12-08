using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static PawnShop.Core.Constants.AdminConstants;

namespace PawnShop.Controllers
{
    [Authorize(Roles = UserRole)]
    public class BaseController : Controller
    {       
        [HttpGet]
        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
