using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.User;
using PawnShop.Infrastructure.Data;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;


namespace PawnShop.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly ApplicationDbContext data;

        private readonly IRepository repository;

        public UserService(
            UserManager<ApplicationUser> _userManager,
            ApplicationDbContext _context,
            IRepository _repository
            )
        {
            userManager = _userManager;
            data = _context;
            repository = _repository;
        }

        public async Task<UpdateUserViewModel> EditAsync(string userId)
        {
            var user = await userManager.FindByIdAsync( userId );
            var model = new UpdateUserViewModel()
            {
                Id = userId,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return model;
        }

        public async Task<IEnumerable<AllUsersViewModel>> AllAsync()
        {
            var users = await repository.AllReadOnly<ApplicationUser>()
                .Include(a => a.Client)
                .Where(e => e.Email != null && e.Email != "admin@abv.bg")
              //  .Where(e => e.Client.IsDeleted == false)
                .Where(e => e.Client == null || e.Client.IsDeleted == false)
                .Select(c => new AllUsersViewModel()
                {
                    UserId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email ?? string.Empty,
                    PhoneNumber = c.Client != null ? c.Client.PhoneNumber : string.Empty,
                    IsClient = c.Client != null
                })
                .ToListAsync();

            return users;

        }

        public async Task<bool> ExistUserIdAsync(string userId)
        {
            return await data.Clients.AnyAsync(x => x.UserId == userId);
        }


        public async Task<bool> Forget(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            user.PhoneNumber = null;
            user.FirstName = "forgottenUser-GDPR";
            user.Email = null;
            user.LastName = "";
            user.NormalizedEmail = null;
            user.NormalizedUserName = null;
            user.PasswordHash = null;
            user.UserName = "forgottenUser-GDPR";

            var result = await userManager.UpdateAsync(user);

            return result.Succeeded;
        }


        public async Task<IdentityResult> UpdateUserAsync(string userId, UpdateUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "User not found."
                });
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            var result = await userManager.UpdateAsync(user);

            return result;
        }

    }
}

