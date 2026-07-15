using Fondacia.Core.Interfaces;
using Fondacia.Core.Models.PersonnelUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fondacia.Controllers
{
    public class PersonnelController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPersonnel _personnelService;

        public PersonnelController(
            UserManager<IdentityUser> userManager,
            IPersonnel personnelService)
        {
            _userManager = userManager;
            _personnelService = personnelService;
        }

        // GET: Personnel/Create

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreatePersonnelViewModel());
        }

        // POST: Personnel/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreatePersonnelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Този email вече е регистриран.");
                return View(model);
            }

            var identityUser = await _personnelService.CreateIdentityUserAsync(model.Email, model.Password);

            if (identityUser == null)
            {
                ModelState.AddModelError("", "Failed to create user.");

                return View(model);
            }


            // 2) Създаваме Personnel
            var currentUser = GetUserId();

            var result = await _personnelService.CreatePersonnelAsync(model, currentUser, identityUser.Id);

            // Ако има грешка (например снимката е над 2 MB)
            if (!result.Success)
            {
                ModelState.AddModelError("Photo", result.ErrorMessage);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> CompleteProfile()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Ако вече има Personnel → нека отиде в профила си
            try
            {
                await _personnelService.FindPersonnelAsync(userId);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                // Personnel not found, continue to complete profile
            }

            return View(new CompleteProfileViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CompleteProfile(CompleteProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var personnel = await _personnelService.CompleteProfileAsync(model, userId);

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            ViewData["Breadcrumbs"] = new List<(string Text, string Url)>
    {
        ("Начало", Url.Action("Index", "Home")),
        ("Моят профил", Url.Action("EditProfile", "Personnel")),
        ("Редакция", null)
    };
            var userId = _userManager.GetUserId(User);

            if (userId == null)
                return RedirectToAction("Login", "Account");


            var model = await _personnelService.GetPersonnelAsync(userId);

            if (model == null)
                return RedirectToAction(nameof(CompleteProfile));


            ViewBag.FormAction = "EditProfile";
            return View("Edit", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            return await SavePerson(model, "EditProfile");

            //    if (!ModelState.IsValid)
            //    {
            //        return View(model);
            //    }

            //    var currentUserId = _userManager.GetUserId(User);

            //    if (currentUserId == null)
            //    {
            //        return RedirectToAction("Login", "Account");
            //    }

            //    var personnel = await _personnelService.EditPersonnelAsync(model, currentUserId);

            //    if (personnel == null)
            //    {
            //        return NotFound();
            //    }

            //    return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditPerson(Guid id)
        {
            var model = await _personnelService.GetPersonnelForEditAsync(id);

            if (model == null)
                return NotFound();

            ViewBag.FormAction = "EditPerson";
            return View("Edit", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditPerson(EditProfileViewModel model)
        {
            return await SavePerson(model, "EditPerson");

            //    if (!ModelState.IsValid)
            //    {
            //        return View(model);
            //    }

            //    var currentUserId = _userManager.GetUserId(User);

            //    if (currentUserId == null)
            //    {
            //        return RedirectToAction("Login", "Account");
            //    }

            //    var personnel = await _personnelService.EditPersonnelAsync(model, currentUserId);

            //    if (personnel == null)
            //    {
            //        return NotFound();
            //    }

            //    return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AllPersonnel()
        {
            ViewData["Breadcrumbs"] = new List<(string Text, string Url)>
              {
                  ("Начало", Url.Action("Index", "Home")),
                  ("Потребители", null)
              };
            var model = await _personnelService.GetAllPersonnelAsync();
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        private async Task<IActionResult> SavePerson(EditProfileViewModel model, string actionName)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

            var currentUserId = _userManager.GetUserId(User);
            if (currentUserId == null)
                return RedirectToAction("Login", "Account");

            var personnel = await _personnelService.EditPersonnelAsync(model, currentUserId);

            if (personnel == null)
                return NotFound();

            if (actionName == "EditProfile")
                return RedirectToAction(nameof(Index), "Home");

            return RedirectToAction(nameof(AllPersonnel));
        }

    }
}
