using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Helpdesk.Extentions
//namespace  Microsoft.AspNetCore.Identity.EntityFrameworkCore
{
    public static class NameExtentions
    {
        private static readonly UserManager<ApplicationUser> userManager;

        public static string UserFullName(string userId)
        {
           // var user =  userManager.FindByIdAsync(userId);
       
            var fullName = userManager.Users
                .Where(x => x.Id == userId)
                .Select(x => x.FirstName + " " + x.LastName)
                .FirstOrDefault();

            return fullName ?? string.Empty;
        }


    }
}
