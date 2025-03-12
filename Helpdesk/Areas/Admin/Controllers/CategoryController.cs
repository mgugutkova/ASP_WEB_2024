using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Categoris;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoriesService categoriesService;

        public CategoryController(ICategoriesService _categoriesService)
        {
            categoriesService = _categoriesService;
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            var model = new AllCategoriesViewModel();

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddCategory(AllCategoriesViewModel model)
        {
            if (model != null)
            {
                await categoriesService.AddCategoryAsync(model.Name);
            }

            return RedirectToAction(nameof(AllCategories));
        }

        [HttpGet]
        public async Task<IActionResult> AllCategories()
        {
            var model = await categoriesService.AllCategoriesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var model = await categoriesService.FindCategoryAsync(id);

            if (model == null)
            {
                return RedirectToAction(nameof(AllCategories));
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditCategory(int id, AllCategoriesViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                await categoriesService.EditCategoryAsync(id, model);
            }

            return RedirectToAction(nameof(AllCategories));
        }
    }
}
