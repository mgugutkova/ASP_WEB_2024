using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PawnShop.Core.Interfaces;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Core.Services
{
    public class UserService : IUserService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

   //     public async Task<bool> ExistUserIdAsync()
   //     {
   //         var userName = await _userManager.FindByNameAsync(userName: HttpContext.User.Identity.Name);

			//return true;
   //     }

        // Метод за обновяване на потребителски данни
        public async Task<IdentityResult> UpdateUserAsync(string userId, string newEmail, string newPhoneNumber)
		{
			// Намерете потребителя по неговото ID
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return IdentityResult.Failed(new IdentityError
				{
					Description = "User not found."
				});
			}

			// Променете желаните данни
			user.Email = newEmail;
			user.PhoneNumber = newPhoneNumber;

			// Обновете потребителя в базата данни
			var result = await _userManager.UpdateAsync(user);

			return result;
		}
	}
}

