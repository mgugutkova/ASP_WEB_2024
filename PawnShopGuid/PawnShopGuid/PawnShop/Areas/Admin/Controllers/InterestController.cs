using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;

namespace PawnShop.Areas.Admin.Controllers
{
    public class InterestController : AdminBaseController
    {
        private readonly IInterestService interestService;

        public InterestController(IInterestService _interestService)
        {
            interestService = _interestService;
        }

        [HttpGet]
        public async Task<IActionResult> All(string id)
        {
            Guid agreementId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref agreementId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(Index), "Admin");
            }
            var model = await interestService.GetAllInterestsAsync(agreementId);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteInterest(string id)
        {
            Guid interestId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref interestId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(Index), "Admin");
            }
            var model = await interestService.DeleteInterestAsync(interestId);

            if (model == null)
            {
                return View("BadRequest");
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            Guid interestId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref interestId);

            if (isValidGuid)
            {
                await interestService.DeleteConfirmedAsync(interestId);
            }

            return RedirectToAction("All", "Agreement");
        }
    }
}
