using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Core.Models.Categoris
{
    public class AllCategoriesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength, ErrorMessage = ErrorMessageLength)]
        public string Name { get; set; } = string.Empty;
    }
}
