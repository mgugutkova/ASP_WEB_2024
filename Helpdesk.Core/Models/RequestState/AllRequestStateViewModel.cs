using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Core.Models.RequestState
{
    public class AllRequestStateViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RequestNameMaxLength)]
        [StringLength(RequestNameMaxLength, MinimumLength = RequestNameMinLength, ErrorMessage = ErrorMessageLength)]
        public string Name { get; set; } = string.Empty;
    }
}
