using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AllRequests()
        {
            
            var requests = await requestService.AllRequestAsync();
            ViewBag.Time = DateTime.Now.ToString("HH:mm:ss.fff");

            if (requests == null)
            {
                return NotFound();
            }

            return View(requests);
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
                return PartialView("EditPartial", model);
            }
            await requestService.EditRequestAsync(model.Id, model);

           // return Ok();
          // return RedirectToAction(nameof(AllRequests));
            return Json(new { success = true });
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
