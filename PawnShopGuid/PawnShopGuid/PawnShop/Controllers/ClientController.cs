using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Client;
using static PawnShop.Core.Constants.AdminConstants;

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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> BecomeClient(BecomeClientFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var rezault = await clientService.CreateClientAsync(GetUserId(), model.PhoneNumber, model.Address);

            if (!rezault)
            {
                return View("BadRequest");
            }

            return View("LoginAgain");  
        }

        [HttpGet]
        public async Task<IActionResult> MineAgreements()
        {
            var currentUserId = GetUserId();

            bool isClientHasAgreement = await clientService.ClientHasAgreementAsync(currentUserId);

            if (isClientHasAgreement == false)
            {
                return RedirectToAction("Add", "Agreement");
            }

            var model = await clientService.GetClientAgreementAsync(currentUserId); 

            return View(model);
        }

       
    }
}
