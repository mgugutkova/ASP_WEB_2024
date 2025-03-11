using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class AdminController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
