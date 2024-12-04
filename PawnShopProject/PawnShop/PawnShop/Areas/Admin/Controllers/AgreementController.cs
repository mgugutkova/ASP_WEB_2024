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
            //  query.AgreementStates = await agreementService.AllStatesNamesAsync();

            return View(query);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await agreementService.IsAgreementExistAsync(id) == false)
            {
                return View("BadRequest");
            }

            var model = await agreementService.GetAgreementAsync(id);

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
            if (await agreementService.IsAgreementExistAsync(model.Id) == false)
            {
                return View("BadRequest");
            }

            if (!ModelState.IsValid)
            {
                model.AgreementsStates = await agreementService.GetStatesAsync();

                return View(model);
            }

            await agreementService.EditAgreementAsync(model.Id, model);

            return RedirectToAction(nameof(Details), new { model.Id });

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await agreementService.IsAgreementExistAsync(id) == false)
            {
                return View("BadRequest");
            }

            var model = await agreementService.FindAgreementAsync(id);

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
        public async Task<IActionResult> DeleteAgreement(int id)
        {
            if (await agreementService.IsAgreementExistAsync(id) == false)
            {
                return View("BadRequest");
            }

            var model = await agreementService.DeleteAgreementAsync(id);

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await agreementService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }
    }
}

