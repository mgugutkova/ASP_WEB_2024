using Microsoft.AspNetCore.Identity;
using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.User;

namespace PawnShop.Core.Interfaces
{
	public interface IUserService
	{
		Task<UpdateUserViewModel> EditAsync(string userId);

        Task<IdentityResult> UpdateUserAsync(string userId, UpdateUserViewModel model);

		Task<bool> ExistUserIdAsync(string userId);

		Task<IEnumerable<AllUsersViewModel>> AllAsync();

		Task <bool>Forget(string userId);
    }
}
