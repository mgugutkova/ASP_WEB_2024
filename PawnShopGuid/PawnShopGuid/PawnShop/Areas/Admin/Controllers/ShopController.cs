using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Shop;

namespace PawnShop.Areas.Admin.Controllers
{
    public class ShopController : AdminBaseController
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
        public async Task<IActionResult> Edit(string id)
        {
            Guid goodsId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref goodsId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await shopService.FindAsync(goodsId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditGoodsInShop model)
        {
            var goodsId = Guid.Parse(model.Id);

            if (!ModelState.IsValid)
            {
                return View("BadRequest");
            }

            await shopService.EditAsync(goodsId, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            Guid goodsId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref goodsId);

            if (!isValidGuid)
            {
                return RedirectToAction(nameof(All));
            }
            var model = await shopService.DeleteAsync(goodsId);

            return View("DeleteGoods", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            Guid goodsId = Guid.NewGuid();

            bool isValidGuid = IsGuidValid(id, ref goodsId);

            if (isValidGuid)
            {
                await shopService.DeleteConfirmedAsync(goodsId);
            }

            return RedirectToAction(nameof(All));
        }
    }
}
