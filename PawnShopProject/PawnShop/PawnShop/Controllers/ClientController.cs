using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Client;
using System.Security.Claims;

namespace PawnShop.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService _clientService)
        {
            clientService = _clientService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomeClient()
        {
            var currentUserId = GetUserId();

            bool IsClientExist = await clientService.ExistClientIdAsync(currentUserId);

            if (IsClientExist)
            {
               return View("ClientExist");
            }
        
            var model = new BecomeClientFormModel();

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> BecomeClient(BecomeClientFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await clientService.CreateClientAsync(GetUserId(), model.PhoneNumber, model.Address);

            return RedirectToAction(nameof(Index), "Home");   // да връща към всички договори
        }

       

        [HttpGet]
		private string GetUserId()
		{
			return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}
	}
}
