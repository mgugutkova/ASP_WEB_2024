
namespace Helpdesk.Core.Models.ApplicationUser
{
    public class UsersServiceQueryModel
    {
        public int TotalUsersCount { get; set; }   
        public int TotalPagesCount { get; set; }
        public int UsersPerPage { get; set; } = 5;
        public IEnumerable<UserViewModel> UsersLists { get; set; } = new HashSet<UserViewModel>();
    }
}
