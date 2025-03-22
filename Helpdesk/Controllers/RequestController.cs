using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService _requestService)
        {
            requestService = _requestService;
        }

        [HttpGet]
        public async Task<IActionResult> MyRequests()
        {
            var currentUser = GetUserId();

            var model = await requestService.MyRequestAsync(currentUser);

            return View(model);
        }

        [HttpGet]
        public  async Task<IActionResult> AddRequest()
        {            
            var model = new RequestViewModel();

            model.CategoryList = await requestService.AllCategoryList(); 

            return View(model);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddRequest(RequestViewModel model)
        {
            model.UserId = GetUserId();

            await requestService.AddRequestAsync(model.Description, model.CategoryId);

           // return RedirectToAction(nameof(MyRequests), new { model.UserId });  
            return RedirectToAction(nameof(MyRequests));  
        }
    }
}
