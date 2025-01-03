using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Agreement;
using PawnShop.Infrastructure.Data.Model;
using System.Security.Claims;

namespace PawnShop.Areas.Admin.Controllers
{
    public class AgreementController : AdminBaseController
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


        [HttpPost]
        public async Task<IActionResult> AllAgreements(string userId)
        {
            var model = await agreementService.AllAgreementsAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllAgreementQueryViewModel query)
        {
            var model = await agreementService.AllAsync(
                query.State,
                query.SearchItem,
                query.Sorting,
                query.CurrentPage,
                query.AgreementPerPage);

            query.TotalAgreementCount = model.TotalAgreementCount;
            query.Agreements = model.AgreementsList;

            return View(query);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Guid agreementId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(All));
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

            if (model.UserId != currentUser?.Id && User.IsAdmin() == false)
            {
                return View("Unauthorized");
            }

            return View(model);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(AddAgreementViewModel model)
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

            return RedirectToAction(nameof(Details), new { agreementId });

        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid agreementId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(All));
            }

            if (await agreementService.IsAgreementExistAsync(agreementId) == false)
            {
                return View("BadRequest");
            }

            var model = await agreementService.FindAgreementAsync(agreementId);

            if (model == null)
            {
                return View("BadRequest");
            }

            var currentUser = await userManager.FindByIdAsync(User.Id() ?? string.Empty);

            if (model.UserId != currentUser?.Id && User.IsAdmin() == false)
            {
                return View("Unauthorized");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAgreement(string id)
        {
            Guid agreementId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(All));
            }

            if (await agreementService.IsAgreementExistAsync(agreementId) == false)
            {
                return View("BadRequest");
            }

            var model = await agreementService.DeleteAgreementAsync(agreementId);

            if (model == null)
            {
                return View("BadRequest");
            }

            var currentUser = await userManager.FindByIdAsync(User.Id() ?? string.Empty);

            if (model.UserId != currentUser?.Id && User.IsAdmin() == false)
            {
                return View("Unauthorized");
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Guid agreementId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            if (isValidGuid)
            {
                await agreementService.DeleteConfirmedAsync(agreementId);
            }

            return RedirectToAction(nameof(All));
        }
    }
}

