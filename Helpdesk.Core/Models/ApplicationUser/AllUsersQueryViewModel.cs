using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Models.ApplicationUser
{
    public class AllUsersQueryViewModel
    {
        public int UsersPerPage { get; set; } = 5;

        [Display(Name = "Search by text")]
        public string SearchItem { get; set; } = null!;
        public int CurrentPage { get; set; } = 1;
        public int TotalUsersCount { get; set; }  
        public int TotalPages{ get; set; }  
        public IEnumerable<UserViewModel> UsersListAll { get; set; } = new HashSet<UserViewModel>();
    }
}
