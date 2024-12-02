using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Shop;
using static PawnShop.Core.Constants.AdminConstants;

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
        public async Task<IActionResult> All()
        {
            var model = await shopService.AllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllNotSold()
        {
            var model = await shopService.AllNotSoldAsync();

            return View(nameof(All), model);
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await shopService.FindAsync(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditGoodsInShop model)
        {         

            await shopService.EditAsync(model.Id, model);

            return RedirectToAction(nameof(AllNotSold));
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await shopService.DeleteAsync(id);

            return View("DeleteGoods", model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await shopService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult>Buy(int id)
        {
            await shopService.BuyAsync(id);

            return View();
        }

    }
}
