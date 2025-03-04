using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Directorates;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Controllers
{
    public class DirectorateController : BaseController
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
        public async Task<IActionResult> AddDirectorate()
        {
            var model = new AllDirectoratesViewModel();

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddDirectorate(AllDirectoratesViewModel model)
        {
            if (model == null) { }

            await directoratesService.AddDirectoratesAsync(model.Name);

            return RedirectToAction(nameof(AllDirectoratesMI));
        }

    }
}
