using Microsoft.AspNetCore.Identity;

namespace PawnShop.Core.Interfaces
{
	public interface IUserService
	{
		Task<IdentityResult> UpdateUserAsync(string userId, string newEmail, string newPhoneNumber);

		//Task<bool> ExistUserIdAsync();

    }
}
