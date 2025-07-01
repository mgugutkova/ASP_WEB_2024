using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IRequestService requestService;
       // private readonly UserManager<ApplicationUser> userManager;

        public RequestController(
            IRequestService _requestService)
           // UserManager<ApplicationUser> _userManager)
        {
            requestService = _requestService;
           // userManager = _userManager;
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

            var bulgariaTime = DateTime.UtcNow;
            TimeZoneInfo bulgariaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
            DateTime startDate = TimeZoneInfo.ConvertTimeFromUtc(bulgariaTime, bulgariaTimeZone);
            model.StartDate = startDate;


            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddRequest(RequestViewModel model)
        {
            model.UserId = GetUserId();

            await requestService.AddRequestAsync(model.Description, model.CategoryId, model.Attachment);

           // return RedirectToAction(nameof(MyRequests), new { model.UserId });  
            return RedirectToAction(nameof(MyRequests));  
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await requestService.FindRequestAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            model.CategoryList = await requestService.AllCategoryList();

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Detail(Guid id, RequestViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await requestService.EditRequestAsync(id, model);

            return RedirectToAction(nameof(MyRequests));
        }

        [HttpGet]
        public async Task<IActionResult> DownloadAttachment(Guid id)
        {
            var request = await requestService.FindRequestAsync(id);
               

            if (request == null || request.Attachment == null || request.Attachment.Length == 0)
            {
                return NotFound("Файлът не е намерен.");
            }

            using var memoryStream = new MemoryStream();
            await request.Attachment.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();

            return File(fileBytes, "application/octet-stream", request.FileName);
        }       

    }
}
