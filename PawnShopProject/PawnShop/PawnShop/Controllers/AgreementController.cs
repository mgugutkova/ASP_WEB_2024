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
			var model = await agreementService.All();

			return View(model);
		}


		[HttpGet]
		public async Task<IActionResult> Add() 
		{
			var model = new AddAgreementViewModel();

			model.AgreementsStates = await agreementService.GetStates();			

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
			return RedirectToAction(nameof(Index), "Home");

		}      
    }
}
