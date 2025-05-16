using Helpdesk.Core.Enumeration;
using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.ApplicationUser;
using Helpdesk.Core.Models.Directorates;
using Helpdesk.Infrastructure.Data.Model;
using Helpdesk.Infrastructure.Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            Status sortItem = Status.Active,
            int dirId = 0,
            int currentPage = 1,
            int usersPerPage = 1)
        {

            var usersAll = userManager.Users.AsQueryable();         

            if (sortItem == Status.NoActive)
            {
                usersAll = userManager.Users
                    .Where(x => x.IsActive == false);
            }
            else if (sortItem == Status.All)
            {
                usersAll = userManager.Users
                    .Where(x => x.UserName != null);
            }
            else if (sortItem == Status.Active)
            {
                usersAll = userManager.Users
                    .Where(x => x.IsActive == true);
            }


            if (searchTerm != null)
            {
                string normalizeSearchTerm = searchTerm.ToLower();

                usersAll = usersAll
                    .Where(x =>
                       x.FirstName.ToLower().Contains(normalizeSearchTerm) ||
                       x.LastName.ToLower().Contains(normalizeSearchTerm) ||
                       x.Address.ToLower().Contains(normalizeSearchTerm) ||
                       x.Email.ToLower().Contains(normalizeSearchTerm) ||
                       x.UserName.ToLower().Contains(normalizeSearchTerm)
                       );       
            }


            if (dirId != 0)
            {
                usersAll = usersAll
                   .Where(x => x.DirectoratesUnitId == dirId);                        
            }      


            var findUsersCount = usersAll.Count();

            var usersToShow = await usersAll
                  .Skip((currentPage - 1) * usersPerPage)
                  .Take(usersPerPage)
                  .Select(x => new UserViewModel()
                  {
                      UserId = x.Id,
                      UserName = x.UserName ?? string.Empty,
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
                  .ToListAsync();

            var totalPagesCount = (int)Math.Ceiling((double)findUsersCount / usersPerPage);

            return new UsersServiceQueryModel
            {               
                TotalUsersCount = await userManager.Users.CountAsync(),
                FoundUsersCount = findUsersCount,
                TotalPagesCount = totalPagesCount,
                UsersPerPage = usersPerPage,
                UsersLists = usersToShow
            };
        }

        public async Task EditUserByIdAsync(string userId, UpdateUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return;
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            user.Position = model.Position;
            user.DirectoratesUnitId = model.DirectoratesUnitId;
            user.IsActive = model.IsActive;
            user.RoleName = model.RoleName;

            await userManager.AddToRoleAsync(user, model.RoleName);

            await repository.SaveChangesAsync();
        }

        public async Task<UpdateUserViewModel?> GetUserByIdAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var model = new UpdateUserViewModel()
            {
                UserId = userId,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber ?? string.Empty,
                Position = user.Position,
                RoleName = Enum.Parse(typeof(RoleNameItems), user.RoleName).ToString() ?? string.Empty,
                IsActive = user.IsActive,
                DirectoratesUnitId = user.DirectoratesUnitId,
                DirectoratesList = await repository.All<DirectoratesUnit>()
                    .Select(d => new AllDirectoratesViewModel
                    {
                        Id = d.Id,
                        Name = d.Name
                    })
                    .ToListAsync()
            };

            return model;
        }
    }
}
