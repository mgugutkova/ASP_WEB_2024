﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Interest;
using PawnShop.Infrastructure.Data.Model;
using static PawnShop.Core.Constants.AdminConstants;

namespace PawnShop.Controllers
{
    public class InterestController : BaseController
    {
        private readonly IInterestService interestService;
        private readonly IAgreementService agreementService;
    

        public InterestController(IInterestService _interestService,
            IAgreementService _agreementService
          )
        {
            interestService = _interestService;
            agreementService = _agreementService;
          
        }


        [HttpGet]
        public async Task<IActionResult> AddInterest(int agreementId)
        {
            var agreementModel = await agreementService.FindAgreementAsync(agreementId);

            if (agreementModel == null)
            {
                return View("BadRequest");
            }

            var model = new AddInterestViewModel()
            {
                AgreementId = agreementId,
                ValueInterest = agreementModel.ReturnPrice - agreementModel.Price,
                AgreementViewModel = agreementModel
            };

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AddInterest(AddInterestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserId = GetUserId();

            await interestService.AddInterestAsync(model.AgreementId, currentUserId);

            return RedirectToAction(nameof(AllInterests), new { model.AgreementId });
        }


        [HttpGet]
        public async Task<IActionResult> AllInterests(int agreementId)
        {
            var model = await interestService.GetAllInterestsAsync(agreementId);

            if (model.Count() == 0)
            {
                return RedirectToAction(nameof(AddInterest), new { agreementId });
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = AdminRole)]
        public async Task<IActionResult> DeleteInterest(int id)
        {
            var model = await interestService.DeleteInterestAsync(id);

            if (model == null)
            {
                return View("BadRequest");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await interestService.DeleteConfirmedAsync(id);

            return RedirectToAction("AllAgreements", "Agreement");

        }
    }
}
