using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Shop;
using PawnShop.Core.Services;
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

            return RedirectToAction(nameof(All));
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

    }
}
