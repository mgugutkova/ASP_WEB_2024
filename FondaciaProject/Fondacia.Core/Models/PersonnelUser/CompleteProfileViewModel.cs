using Fondacia.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace Fondacia.Core.Models.PersonnelUser
{
    public class CompleteProfileViewModel
    {
        [Required]
        [StringLength(DataConstants.FullNameMaxLength, MinimumLength = DataConstants.FullNameMinLength, ErrorMessage = DataConstants.ErrorMessageLength)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstants.ShortNameMaxLength, MinimumLength = DataConstants.ShortNameMinLength, ErrorMessage = DataConstants.ErrorMessageLength)]
        public string ShortName { get; set; } = string.Empty;

        public string? Notice { get; set; }
    }

}
