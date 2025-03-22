using Helpdesk.Core.Interfaces;
using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }
        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var userItems = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Position = user.Position,
                DirectoratesUnit = user.DirectoratesUnit
            };
            return userItems;
        }
    }
}
