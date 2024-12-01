using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PawnShop.Core.Constants.AdminConstants;

namespace PawnShop.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {      
    }
}
