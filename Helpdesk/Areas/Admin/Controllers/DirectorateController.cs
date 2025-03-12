using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Directorates;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class DirectorateController : AdminBaseController
    {
        private readonly IDirectoratesService directoratesService;

        public DirectorateController(IDirectoratesService _directoratesService)
        {
            directoratesService = _directoratesService;
        }

        [HttpGet]
        public async Task<IActionResult> AllDirectoratesMI()
        {
            var model = await directoratesService.AllDirectoratesAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddDirectorate()
        {
            var model = new AllDirectoratesViewModel();

            return View(model);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddDirectorate(AllDirectoratesViewModel model)
        {
            if (model != null)
            {
                await directoratesService.AddDirectorateAsync(model.Name);
            }

            return RedirectToAction(nameof(AllDirectoratesMI));
        }

        [HttpGet]
        public async Task<IActionResult> EditDirectorate(int id)
        {
            var model = await directoratesService.FindDirectorateAsync(id);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                return RedirectToAction(nameof(AllDirectoratesMI));
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditDirectorate(AllDirectoratesViewModel model, int id)
        {
            if (model == null || model.Id != id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await directoratesService.EditDirectorateAsync(id, model);

            return RedirectToAction(nameof(AllDirectoratesMI));
        }
    }
}
