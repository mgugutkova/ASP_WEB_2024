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

			if (model.Count() == 0)
			{
				return RedirectToAction(nameof(Add));
			}

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

			var currentUserId =  GetUserId();

            await agreementService.CreateAgreementAsync(currentUserId,
				model.GoodName,
				model.Description ?? string.Empty,
				model.Price,
				model.Duration);

			return RedirectToAction(nameof(AllAgreements));

		}

        [HttpGet]
        public async Task<IActionResult> EditAgreement(int id)
        {
			var model = await agreementService.GetAgreementAsync(id);

			if (model == null)
			{
				return View("BadRequest");
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

			return RedirectToAction(nameof(AllAgreements));
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAgreement(int id)
		{
			var model = await agreementService.DeleteAgreementAsync(id);

            if (model == null)
            {
                return View("BadRequest");
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
