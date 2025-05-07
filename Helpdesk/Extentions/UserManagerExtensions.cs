using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Helpdesk.Extentions
{
    public static class UserManagerExtensions
    {
        public static async Task<string> GetFullNameAsync(this UserManager<ApplicationUser> userManager, ClaimsPrincipal userPrincipal)
        {
            var user = await userManager.GetUserAsync(userPrincipal);
            if (user == null)
            {
                return "Unknown User";
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
