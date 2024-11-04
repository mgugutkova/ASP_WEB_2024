using PawnShop.Core.Interfaces;
using PawnShop.Infrastructure.Data;

namespace PawnShop.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext data;

        public ApplicationUserService(ApplicationDbContext context)
        {
            data = context;
        }

        public async Task<string> UserFullName(string userId)
        {
            var user = await data.Users.FindAsync(userId);
            if (user == null)
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(user.FirstName) 
                || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }
            
            return user.FirstName + ' ' + user.LastName;
        }
    }
}
