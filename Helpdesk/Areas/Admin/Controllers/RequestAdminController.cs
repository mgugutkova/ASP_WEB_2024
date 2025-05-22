using Helpdesk.Core.Interfaces;
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
    }
}
