using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;

namespace PawnShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService shopService;

        public ShopController(IShopService _shopService)
        {
            shopService = _shopService;
        }
  

        [HttpGet]
        public async Task<IActionResult> AllNotSold()
        {
            var model = await shopService.AllNotSoldAsync();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult>Buy(int id)
        {
            await shopService.BuyAsync(id);

            return View();
        }
    }
}
