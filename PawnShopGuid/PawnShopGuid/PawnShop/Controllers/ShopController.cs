using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;

namespace PawnShop.Controllers
{
    public class ShopController : BaseController
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
        public async Task<IActionResult> Buy(string id)
        {
            Guid goodsId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref goodsId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(AllNotSold));
            }

            await shopService.BuyAsync(goodsId);

            return View();
        }
    }
}
