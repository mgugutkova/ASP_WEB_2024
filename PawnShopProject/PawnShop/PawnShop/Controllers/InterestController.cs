using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Interest;

namespace PawnShop.Controllers
{
    public class InterestController : BaseController
    {
        private readonly IInterestService interestService;
        private readonly IAgreementService agreementService;
    

        public InterestController(IInterestService _interestService,
            IAgreementService _agreementService
          )
        {
            interestService = _interestService;
            agreementService = _agreementService;
          
        }


        [HttpGet]
        public async Task<IActionResult> AddInterest(int agreementId)
        {
            var agreementModel = await agreementService.FindAgreementAsync(agreementId);

            if (agreementModel == null)
            {
                return View("BadRequest");
            }

            var model = new AddInterestViewModel()
            {
                AgreementId = agreementId,
                ValueInterest = agreementModel.ReturnPrice - agreementModel.Price,
                AgreementViewModel = agreementModel
            };

            return View(model);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddInterest(AddInterestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("BadRequest");
            }

            var currentUserId = GetUserId();

            await interestService.AddInterestAsync(model.AgreementId, currentUserId);

            return RedirectToAction(nameof(AllInterests), new { model.AgreementId });
        }


        [HttpGet]
        public async Task<IActionResult> AllInterests(int agreementId)
        {
            var model = await interestService.GetAllInterestsAsync(agreementId);

            if (model.Count() == 0)
            {
                return RedirectToAction(nameof(AddInterest), new { agreementId });
            }

            return View(model);
        }      
    }
}
