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
        public async Task<IActionResult> All(int agreementId)
        {
            var model = await interestService.GetAllInterestsAsync(agreementId);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            var model = await interestService.DeleteInterestAsync(id);

            if (model == null)
            {
                return View("BadRequest");
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await interestService.DeleteConfirmedAsync(id);

            return RedirectToAction("All", "Agreement");

        }
    }
}
