
using System.ComponentModel;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Core.Models.ApplicationUser
{
    public class UsersServiceQueryModel
    {
        public int TotalUsersCount { get; set; }
        public int FoundUsersCount { get; set; }
        public int dirId { get; set; }
        public int TotalPagesCount { get; set; }
        public int UsersPerPage { get; set; } = ItemsPerPage;
        public IEnumerable<UserViewModel> UsersLists { get; set; } = new HashSet<UserViewModel>();
    }
}
