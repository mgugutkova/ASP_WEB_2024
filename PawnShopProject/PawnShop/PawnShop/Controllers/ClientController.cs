using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Client;

namespace PawnShop.Controllers
{

    public class ClientController : BaseController
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
        public async Task<IActionResult> MineContracts(string userId)
        {
            var currentUserId = GetUserId();

            if (string.IsNullOrEmpty(userId) || currentUserId != userId)
            {
                return BadRequest("You get an error!");
            }

            int clientId = await clientService.GetClientIdAsync(userId);

            if (clientId == 0)
            {
                return BadRequest("You get an error!");
            }

            bool isClientHasContract = await clientService.ClientHasAgreementAsync(userId);

            if (isClientHasContract == false)
            {
                return BadRequest("You get an error!");
            }

            // todo generate model/view
            return View();
        }

   
    }
}
