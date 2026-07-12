using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fondacia.Core.Models.PersonnelUser
{
    public class EditProfileViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        public string? Notice { get; set; }

        public bool IsActive { get; set; }

        public string? ExistingPhotoBase64 { get; set; }

      //  [MaxLength(2 * 1024 * 1024, ErrorMessage = "Снимката трябва да бъде до 2 MB.")]
        public IFormFile? Photo { get; set; }

    }

}
