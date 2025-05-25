using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class RequestAdminController : AdminBaseController
    {
        private readonly IRequestService requestService;

        public RequestAdminController(IRequestService _requestService)
        {
            requestService = _requestService;
        }

        [HttpGet]
        public async Task<IActionResult> AllRequests()
        {
            var requests = await requestService.AllRequestAsync();

            if (requests == null)
            {
                return NotFound();
            }

            return View(requests);            
        }

        [HttpGet]
        public async Task<IActionResult> DetailsPartial(Guid id)
        {
            var model = await requestService.FindRequestAsync(id);
          
            if (model == null)
                return NotFound(); // Важно!

            return PartialView(model);
            //return PartialView("_ProductDetails", request);  
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(Guid id)
        {
            var model = await requestService.FindRequestAsync(id);

            if (model == null)
                return NotFound(); // Важно!

            return PartialView(model);

           // return PartialView("_ProductEditPartial", product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("EditPartial", model);
            }
            await requestService.EditRequestAsync(model.Id, model);

            return Ok();
           // return RedirectToAction("AllRequests");
        }

    }
}
