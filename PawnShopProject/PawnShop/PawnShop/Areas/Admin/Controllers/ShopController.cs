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
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(EditGoodsInShop model)
        {
            if (!ModelState.IsValid)
            {
                return View("BadRequest");
            }

            await shopService.EditAsync(model.Id, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]      
        public async Task<IActionResult> Delete(int id)
        {
            var model = await shopService.DeleteAsync(id);

            return View("DeleteGoods", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await shopService.DeleteConfirmedAsync(id);

            return RedirectToAction(nameof(All));
        }    
    }
}
