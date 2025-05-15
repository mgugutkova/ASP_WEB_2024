using Helpdesk.Core.Enumeration;
using Helpdesk.Core.Models.Directorates;
using Helpdesk.Infrastructure.Data.Model;

namespace Helpdesk.Core.Models.ApplicationUser
{
    public class UpdateUserViewModel
    {
       
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
      
        public string Email { get; set; } = string.Empty;
       
        public string FirstName { get; set; } = string.Empty;
      
        public string LastName { get; set; } = string.Empty;
      
        public string Address { get; set; } = string.Empty;
     
        public string PhoneNumber { get; set; } = string.Empty;

        public int DirectoratesUnitId { get; set; }
       // public DirectoratesUnit DirectoratesUnit { get; set; } = null!;
      //  public string DirectorateName { get; set; } = null!;

        public string? Position { get; set; } = null;
    
        public string RoleName { get; set; } = string.Empty;  

        //public virtual ICollection<RequestViewModel> Requests { get; set; } = new HashSet<RequestViewModel>();

        public IEnumerable<AllDirectoratesViewModel> DirectoratesList { get; set; } = new HashSet<AllDirectoratesViewModel>();
    }
}
