using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class RequestAdminController : AdminBaseController
    {
        private readonly IRequestService requestService;
        private readonly IRequestStateService requestStateService;

        public RequestAdminController(
            IRequestService _requestService,
            IRequestStateService _requestStateService)
        {
            requestService = _requestService;
            requestStateService = _requestStateService;
        }

        [HttpGet]
        public async Task<IActionResult> RequestsPage(int stateId = 0, int skip = 0, int take = 10)
        {
            var data = await requestService.GetPagedAsync(skip, take, stateId);

            return PartialView("_RequestsTable", data);
        }


        [HttpGet]
        public IActionResult AllRequests()
        {
            ViewBag.Time = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            ViewBag.Title = "Всички Заявки !!! ";

            return View();
        }

        [HttpGet]
        public IActionResult ClosedRequests()
        {
            ViewBag.Time = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            ViewBag.Title = "Затворени Заявки !!! ";

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RequestsTable()
        {
            var requests = await requestService.AllRequestAsync();
            if (requests == null)
            {
                return NotFound();
            }
            return PartialView("_RequestsTable", requests);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsPartial(Guid id)
        {
            var model = await requestService.FindRequestAsync(id);

            if (model == null)
                return NotFound(); // Важно!

            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(Guid id)
        {
            var model = await requestService.FindRequestAsync(id);

            if (model == null)
            {
                return NotFound(); // Важно!
            }

            model.StateList = await requestStateService.AllRequestStateAsync();

            return PartialView(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(RequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }
            await requestService.EditRequestAsync(model.Id, model);

            var updatedRow = await requestService.GetRowAsync(model.Id);

            return Json(new
            {
                success = true,
                row = updatedRow
            });
        }

        [HttpGet]
        public async Task<IActionResult> HistoryPartial(Guid id)
        {
            var model = await requestService.AllRequestHistoryAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            return PartialView("HistoryPartial", model);
        }
    }
}
