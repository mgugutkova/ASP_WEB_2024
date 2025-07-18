using Helpdesk.Core.Enumeration;
using Helpdesk.Core.Models.Directorates;
using Helpdesk.Core.Models.Request;
using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Core.Models.ApplicationUser
{
    public class UserViewModel
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = ErrorMessageLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = ErrorMessageLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;


        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = ErrorMessageLength)]
        public string Address { get; set; } = string.Empty;


        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = ErrorMessageLength)]
        public string PhoneNumber { get; set; } = string.Empty;


        [Required]
        public int DirectoratesUnitId { get; set; }       
     
        public DirectoratesUnit DirectoratesUnit { get; set; } = null!;
        public string DirectorateName { get; set; } = null!;


        [MaxLength(PositionMaxLength)]
        [StringLength(PositionMaxLength, MinimumLength = PositionMinLength, ErrorMessage = ErrorMessageLength)]
        public string? Position { get; set; } = null;

        [Required]
        public string RoleName { get; set; } = string.Empty;
        public int CurrentPage { get; set; } 
        public Status SortItem { get; set; } 

        public virtual ICollection<RequestViewModel> Requests { get; set; } = new HashSet<RequestViewModel>();

        public IEnumerable<AllDirectoratesViewModel> DirectoratesList { get; set; } = new HashSet<AllDirectoratesViewModel>();

    }
}
