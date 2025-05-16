using Helpdesk.Core.Enumeration;
using Helpdesk.Core.Models.ApplicationUser;
using Helpdesk.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Interfaces
{
    public interface IUserService
    {
        Task<UpdateUserViewModel?> GetUserByIdAsync(string userId);
        Task EditUserByIdAsync(string userId, UpdateUserViewModel model);

        Task<IEnumerable<UserViewModel>> AllUsersAsync();
        Task<UsersServiceQueryModel> AllUsersQueryAsync(
            string? searchTerm = null,          
           // string? sortItem = null,
            Status sortItem = Status.Active,
            int dirId = 0,
            int currentPage = 1,
            int usersPerPage = 10);
    }
}
