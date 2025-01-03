using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;

namespace PawnShop.Areas.Admin.Controllers
{
    public class AdminController : AdminBaseController
    {
        private readonly IClientService clientService;

        public AdminController(IClientService _clientService)
        {
            clientService = _clientService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]     
        public async Task<IActionResult> DeleteClient(string userId)
        {
            var model = await clientService.DeleteClientAsync(userId);

            var hasAgreement = await clientService.ClientHasAgreementAsync(userId);

            ViewBag.HasAgreement = hasAgreement;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClientConfirmed(string userId)
        {
            await clientService.DeleteClientConfirmendAsync(userId);

            return RedirectToAction("All", "Users");
        }
    }
}
