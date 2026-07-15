using Fondacia.Infrastructure.Constants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fondacia.Core.Models.PersonnelUser
{
    public class CreatePersonnelViewModel
    {
        // Identity
        [Required]
        [EmailAddress]
        [StringLength(DataConstants.EmailMaxLength, MinimumLength = DataConstants.EmailMinLength, ErrorMessage = DataConstants.ErrorMessageLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(DataConstants.PasswordMaxLength, MinimumLength = DataConstants.PasswordMinLength, ErrorMessage = DataConstants.ErrorMessageLength)]
        public string Password { get; set; } = string.Empty;

        // Personnel
        [Required]
        [StringLength(DataConstants.FullNameMaxLength, MinimumLength = DataConstants.FullNameMinLength, ErrorMessage = DataConstants.ErrorMessageLength)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstants.ShortNameMaxLength, MinimumLength = DataConstants.ShortNameMinLength, ErrorMessage = DataConstants.ErrorMessageLength)]
        public string ShortName { get; set; } = string.Empty;

        public string? Notice { get; set; }

        // Upload
        //[MaxLength(DataConstants.maxFileSize, ErrorMessage = "Снимката трябва да бъде до 2 MB.")]
        public IFormFile? Photo { get; set; }

        public bool RemovePhoto { get; set; }

    }
}
