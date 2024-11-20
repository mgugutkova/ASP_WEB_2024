using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Services;
using PawnShop.Models;
using System.Diagnostics;

namespace PawnShop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IClientService clientService;

		public HomeController(ILogger<HomeController> logger,
			IClientService _clientService)
        {
            _logger = logger;
            clientService = _clientService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var currentUserId = GetUserId();

            bool isClientExist = await clientService.ExistClientIdAsync(currentUserId);

            ViewBag.IsClientExist = isClientExist;

            return View(ViewBag);
        }

  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
