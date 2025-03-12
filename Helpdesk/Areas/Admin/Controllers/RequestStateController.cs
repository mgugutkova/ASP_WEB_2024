using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.RequestState;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class RequestStateController : AdminBaseController
    {
        private readonly IRequestStateService stateService;

        public RequestStateController(IRequestStateService _stateService)
        {
            stateService = _stateService;
        }

        [HttpGet]
        public IActionResult AddRequestState()
        {
            var model = new AllRequestStateViewModel();

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddRequestState(AllRequestStateViewModel model)
        {
            if (ModelState.IsValid)
            {
                await stateService.AddRequestStateAsync(model.Name);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            return RedirectToAction(nameof(AllRequestState));
        }

        [HttpGet]
        public async Task<IActionResult> AllRequestState()
        {
            var model = await stateService.AllRequestStateAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRequestState(int id)
        {
            var model = await stateService.FindRequestStateAsync(id);

            if (ModelState.IsValid == false || model == null)
            {
                return RedirectToAction(nameof(AllRequestState));
            }

            return View(model);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditRequestState(int id, AllRequestStateViewModel model)
        {
            await stateService.EditRequestStateAsync(id, model);

            return RedirectToAction(nameof(AllRequestState));
        }

    }
}
