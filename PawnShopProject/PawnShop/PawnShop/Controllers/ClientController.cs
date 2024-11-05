using Microsoft.AspNetCore.Mvc;

namespace PawnShop.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
