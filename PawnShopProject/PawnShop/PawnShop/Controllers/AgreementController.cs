using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Agreement;
using PawnShop.Infrastructure.Data.Model;
using System.Security.Claims;
using static PawnShop.Core.Constants.AdminConstants;

namespace PawnShop.Controllers
{
    public class AgreementController : BaseController
    {
        private readonly IAgreementService agreementService;
        private readonly IClientService clientService;
        private readonly UserManager<ApplicationUser> userManager;

        public AgreementController(
            IAgreementService _agreementService,
            IClientService _clientService,
            UserManager<ApplicationUser> _userManager)
        {
            agreementService = _agreementService;
            clientService = _clientService;
            userManager = _userManager;
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> AllAgreements()
        {
            var model = await agreementService.AllAsync();

            if (model.Count() == 0)
            {
                return RedirectToAction(nameof(Add));
            }

            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = AdminRole)]
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
            query.AgreementStates = await agreementService.AllStatesNamesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddAgreementViewModel();

            model.AgreementsStates = await agreementService.GetStatesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAgreementViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var currentUserId = GetUserId();

            await agreementService.CreateAgreementAsync(currentUserId,
                model.GoodName,
                model.Description ?? string.Empty,
                model.Price,
                model.Duration);

            var user = await userManager.FindByIdAsync(currentUserId);

            if (await userManager.IsInRoleAsync(user, AdminRole))
            {
                return RedirectToAction(nameof(AllAgreements));
            }
            else
            {
                return RedirectToAction("MineAgreements", "Client");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAgreement(int id)
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
        public async Task<IActionResult> EditAgreement(AddAgreementViewModel model)
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


            if (User.IsAdmin())
            {
                return RedirectToAction(nameof(AllAgreements));
            }
            else
            {
                return RedirectToAction("MineAgreements", "Client");
            }
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await agreementService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(AllAgreements));
        }
    }
}
