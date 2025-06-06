﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Directorates;
using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDirectoratesService directorateService;     
        //private readonly IEnumerable<AllDirectoratesViewModel> directoratesMI;

        //private readonly IUserStore<IdentityUser> _userStore;
        //private readonly IUserEmailStore<IdentityUser> _emailStore;
        //private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            // IUserStore<IdentityUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            IDirectoratesService _directorateService       
       
            //ILogger<RegisterModel> logger,
            //IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            directorateService = _directorateService; 
          
            //_userStore = userStore;
            //_emailStore = GetEmailStore();
            //_logger = logger;
            //_emailSender = emailSender;
        }

        public IEnumerable<AllDirectoratesViewModel> directoratesMI {  get; set; } = new List<AllDirectoratesViewModel>();

     
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        ///  
  

        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// </summary>
          	[Required]
            [Display(Name = "Име")]
            [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = ErrorMessageLength)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Фамилия")]
            [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = ErrorMessageLength)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Адрес:")]
            [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = ErrorMessageLength)]
            public string Address { get; set; }


            [Required]
            [Display(Name = "Телефон:")]
            [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = ErrorMessageLength)]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Дирекция:")]
            public int DirectoratesUnitId { get; set; }

            [Required]
            [Display(Name = "Длъжност:")]
            [StringLength(PositionMaxLength, MinimumLength = PositionMinLength, ErrorMessage = ErrorMessageLength)]
            public string Position { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            directoratesMI = await directorateService.GetDirectoratesActive();
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var roleName = "User";

            if (Input.Email.StartsWith("admin@") || (Input.Email.StartsWith("Admin@")))
            {
                roleName = "Admin";
            }       

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Address = Input.Address,
                    PhoneNumber = Input.PhoneNumber,
                    DirectoratesUnitId = Input.DirectoratesUnitId,
                    Position = Input.Position,
                    RoleName = roleName
                };

                //var user = CreateUser();

                //await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                //await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (Input.Email.StartsWith("admin@") || (Input.Email.StartsWith("Admin@")))
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }

                    if (result.Succeeded)
                {
                    //////  //_logger.LogInformation("User created a new account with password.");

                    //////  var userId = await _userManager.GetUserIdAsync(user);
                    //////  var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //////  code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //////  var callbackUrl = Url.Page(
                    //////      "/Account/ConfirmEmail",
                    //////      pageHandler: null,
                    //////      values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //////      protocol: Request.Scheme);

                    ////////  await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //////      $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //////  if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //////  {
                    //////      return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //////  }
                    //////  else
                    //////  {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                    //  }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        //private IdentityUser CreateUser()
        //{
        //    try
        //    {
        //        return Activator.CreateInstance<IdentityUser>();
        //    }
        //    catch
        //    {
        //        throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
        //            $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
        //            $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        //    }
        //}

        //private IUserEmailStore<IdentityUser> GetEmailStore()
        //{
        //    if (!_userManager.SupportsUserEmail)
        //    {
        //        throw new NotSupportedException("The default UI requires a user store with email support.");
        //    }
        //    return (IUserEmailStore<IdentityUser>)_userStore;
        //}       
    }
}
