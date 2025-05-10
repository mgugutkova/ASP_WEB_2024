using Helpdesk.Core.Models.Directorates;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Core.Models.ApplicationUser
{
    public class AllUsersQueryViewModel
    {
        public int UsersPerPage { get; set; } = ItemsPerPage;

        [Display(Name = "Search by text")]
        public string SearchItem { get; set; } = null!;     
        public int dirId { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalUsersCount { get; set; }
        public int FoundUsersCount { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<UserViewModel> UsersListAll { get; set; } = new HashSet<UserViewModel>();
        public IEnumerable<AllDirectoratesViewModel> DirectoratesList { get; set; } = new HashSet<AllDirectoratesViewModel>();
    }
}
