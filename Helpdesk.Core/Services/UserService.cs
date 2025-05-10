using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.ApplicationUser;
using Helpdesk.Infrastructure.Data.Model;
using Helpdesk.Infrastructure.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository repository;

        public UserService
            (UserManager<ApplicationUser> _userManager,
             IRepository _repository)
        {
            userManager = _userManager;
            repository = _repository;
        }

        public async Task<IEnumerable<UserViewModel>> AllUsersAsync()
        {
            var users = await userManager.Users
                .Select(x => new UserViewModel()
                {
                    UserId = x.Id,
                    Email = x.Email ?? string.Empty,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber ?? string.Empty,
                    Position = x.Position,
                    DirectoratesUnit = x.DirectoratesUnit,
                    DirectorateName = x.DirectoratesUnit.Name,
                    RoleName = x.RoleName,
                })
                .OrderBy(x => x.FirstName)
                .ToListAsync();

            return users;
        }

        public async Task<UsersServiceQueryModel> AllUsersQueryAsync(
            string? searchTerm = null,           
            int dirId = 0, 
            int currentPage = 1,
            int usersPerPage = 1)
        {
            var usersAll = await userManager.Users
           .Select(x => new UserViewModel()
           {
               UserId = x.Id,
               Email = x.Email ?? string.Empty,
               FirstName = x.FirstName,
               LastName = x.LastName,
               Address = x.Address,
               PhoneNumber = x.PhoneNumber ?? string.Empty,
               Position = x.Position,
               DirectoratesUnit = x.DirectoratesUnit,
               DirectorateName = x.DirectoratesUnit.Name,
               DirectoratesUnitId = x.DirectoratesUnit.Id,
               RoleName = x.RoleName,
           })
           .OrderBy(x => x.FirstName)
           //.Skip((currentPage - 1) * usersPerPage)
           //.Take(usersPerPage)
           .ToListAsync();

            // var findUsersCount = usersToShow.Count();
            var findUsersCount = usersAll.Count();

            var usersToShow = usersAll
               .Skip((currentPage - 1) * usersPerPage)
               .Take(usersPerPage);
               


            if (searchTerm != null)
            {
                string normalizeSearchTerm = searchTerm.ToLower();

                //  var usersQuery = await userManager.Users
                usersToShow = await userManager.Users

                    .Where(x =>
                       x.FirstName.ToLower().Contains(normalizeSearchTerm) ||
                       x.LastName.ToLower().Contains(normalizeSearchTerm) ||
                       x.Address.ToLower().Contains(normalizeSearchTerm) ||
                       x.Email.ToLower().Contains(normalizeSearchTerm) ||
                       x.UserName.ToLower().Contains(normalizeSearchTerm)
                       )
                     .Select(u => new UserViewModel()
                     {
                         UserId = u.Id,
                         Email = u.Email,
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         Address = u.Address,
                         PhoneNumber = u.PhoneNumber ?? string.Empty,
                         Position = u.Position,
                         DirectoratesUnit = u.DirectoratesUnit,
                         DirectorateName = u.DirectoratesUnit.Name
                         //RoleName = x.RoleName,
                     })
                    .OrderBy(u => u.FirstName)
                    .Skip((currentPage - 1) * usersPerPage)
                    .Take(usersPerPage)
                    .ToListAsync();

                findUsersCount = usersToShow.Count();
            }
           

            if (dirId != 0)
            {
                usersToShow = await userManager.Users
                    .Where(x => x.DirectoratesUnitId == dirId)
                     .Select(u => new UserViewModel()
                     {
                         UserId = u.Id,
                         Email = u.Email,
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         Address = u.Address,
                         PhoneNumber = u.PhoneNumber ?? string.Empty,
                         Position = u.Position,
                         DirectoratesUnit = u.DirectoratesUnit,
                         DirectorateName = u.DirectoratesUnit.Name
                     })
                    .OrderBy(u => u.FirstName)
                    .Skip((currentPage - 1) * usersPerPage)
                    .Take(usersPerPage)
                    .ToListAsync();

                findUsersCount = usersToShow.Count();
            }

         
         //   var totalUsersCount = usersAll.Count();

            var totalPagesCount = (int)Math.Ceiling((double)findUsersCount / usersPerPage);

            return new UsersServiceQueryModel
            {
                // TotalUsersCount = totalUsersCount,
                TotalUsersCount = await userManager.Users.CountAsync(),
                FoundUsersCount = findUsersCount,
                TotalPagesCount = totalPagesCount,
                UsersPerPage = usersPerPage,
                UsersLists = usersToShow

            };
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId) //todo: change to UserViewModel
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var userItems = new ApplicationUser
            {
                Id = user.Id,
                Email = user.Email,
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
