using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Infrastructure.Data;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext data;

        public UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext _context)
        {
            _userManager = userManager;
            data = _context;
        }

        public async Task<bool> ExistUserIdAsync(string userId)
        {
            return await data.Clients.AnyAsync(x => x.UserId == userId);
        }



        public async Task<IdentityResult> UpdateUserAsync(string userId, string newEmail, string newPhoneNumber)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "User not found."
                });
            }

            user.Email = newEmail;
            user.PhoneNumber = newPhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            return result;
        }
    }
}

