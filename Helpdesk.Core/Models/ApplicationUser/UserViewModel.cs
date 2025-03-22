using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Helpdesk.Infrastructure.Constants.DataConstants;
using Helpdesk.Core.Models.Request;

namespace Helpdesk.Core.Models.ApplicationUser
{
    public class UserViewModel
    {
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

        public virtual ICollection<RequestViewModel> Requests { get; set; } = new HashSet<RequestViewModel>();

    }
}
