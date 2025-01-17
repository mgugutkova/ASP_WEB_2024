using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Agreement;
using PawnShop.Infrastructure.Data.Model;
using System.Security.Claims;

namespace PawnShop.Controllers
{
    public class AgreementController : BaseController
    {
        private readonly IAgreementService agreementService;
        private readonly UserManager<ApplicationUser> userManager;

        public AgreementController(
            IAgreementService _agreementService,
            UserManager<ApplicationUser> _userManager)
        {
            agreementService = _agreementService;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddAgreementViewModel();

            model.AgreementsStates = await agreementService.GetStatesAsync();

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(AddAgreementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("BadRequest");
            }

            var currentUserId = GetUserId();

            await agreementService.CreateAgreementAsync(currentUserId,
                model.GoodName,
                model.Description ?? string.Empty,
                model.Price,
                model.Duration);

            var user = await userManager.FindByIdAsync(currentUserId);

            return RedirectToAction("MineAgreements", "Client");

        }


        [HttpGet]
        public async Task<IActionResult> EditAgreement(string id)
        {
            Guid agreementId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            if (!isValidGuid)
            {
                return RedirectToAction("MineAgreements", "Client");
            }

            if (await agreementService.IsAgreementExistAsync(agreementId) == false)
            {
                return View("BadRequest");
            }

            var model = await agreementService.GetAgreementAsync(agreementId);

            if (model == null)
            {
                return View("BadRequest");
            }

            var currentUser = await userManager.FindByIdAsync(User.Id() ?? string.Empty);

            if (model.UserId != currentUser?.Id)
            {
                return View("Unauthorized");
            }

            return View(model);
        }


        [HttpPost]

        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditAgreement(AddAgreementViewModel model)
        {
            var agreementId = Guid.Parse(model.Id);

            if (await agreementService.IsAgreementExistAsync(agreementId) == false)
            {
                return View("BadRequest");
            }

            if (!ModelState.IsValid)
            {
                model.AgreementsStates = await agreementService.GetStatesAsync();

                return View(model);
            }

            await agreementService.EditAgreementAsync(agreementId, model);

            return RedirectToAction("MineAgreements", "Client");
        }       
    }
}
