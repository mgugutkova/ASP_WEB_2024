using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Agreement;

namespace PawnShop.Controllers
{
    public class AgreementController : BaseController
	{
		private readonly IAgreementService agreementService;

        public AgreementController(IAgreementService _agreementService)
        {
            agreementService = _agreementService;
        }

		[HttpGet]
        public async Task<IActionResult> AllAgreements()
		{
			var model = await agreementService.AllAsync();

			return View(model);
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
			if (ModelState.IsValid)
			{
				return BadRequest();
			}

			var currentUserId =  GetUserId();
            await agreementService.CreateAgreementAsync(currentUserId,
				model.GoodName,
				model.Description ?? string.Empty,
				model.Price,
				model.Duration);

			//return RedirectToAction(nameof(Add));
			return RedirectToAction(nameof(AllAgreements));

		}

        [HttpGet]
        public async Task<IActionResult> EditAgreement(int id)
        {
			var model = await agreementService.GetAgreementAsync(id);

            return View(model);
        }


		[HttpPost]
		public async Task<IActionResult> EditAgreement(int id, AddAgreementViewModel model)
		{
			if (await agreementService.IsAgreementExistAsync(id) == false)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				model.AgreementsStates = await agreementService.GetStatesAsync();

				return View(model);
			}

			await agreementService.EditAgreementAsync(id, model);

			return RedirectToAction(nameof(AllAgreements));
		}
    }
}
