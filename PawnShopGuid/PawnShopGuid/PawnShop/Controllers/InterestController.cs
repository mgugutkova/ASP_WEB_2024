using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Interest;

namespace PawnShop.Controllers
{
    public class InterestController : BaseController
    {
        private readonly IInterestService interestService;
        private readonly IAgreementService agreementService;


        public InterestController(
            IInterestService _interestService,
            IAgreementService _agreementService
          )
        {
            interestService = _interestService;
            agreementService = _agreementService;

        }


        [HttpGet]
        public async Task<IActionResult> AddInterest(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return View("BadRequest");
            }
            var agreementId = Guid.Parse(id);

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            var agreementModel = await agreementService.FindAgreementAsync(agreementId);

            if (agreementModel == null)
            {
                return View("BadRequest");
            }

            var model = new AddInterestViewModel()
            {
                AgreementId = id,
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

            var agreementId = Guid.Parse(model.AgreementId);

            await interestService.AddInterestAsync(agreementId, currentUserId);

            string id = model.AgreementId;

            return RedirectToAction(nameof(AllInterests), new { id });
        }


        [HttpGet]
        public async Task<IActionResult> AllInterests(string id)
        {

            Guid agreementId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            if (!isValidGuid)
            {
                return View("BadRequest");
            }

            var model = await interestService.GetAllInterestsAsync(agreementId);


            if (model.Count() == 0)
            {
                ViewBag.AgreementId = id;

                return View("NoInterests");
                // return RedirectToAction(nameof(AddInterest), new { id });

            }

            return View(model);
        }
    }
}
