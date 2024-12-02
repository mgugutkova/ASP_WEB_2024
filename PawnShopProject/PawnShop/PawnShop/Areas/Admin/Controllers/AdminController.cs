using Microsoft.AspNetCore.Mvc;

namespace PawnShop.Areas.Admin.Controllers
{
    public class AdminController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
