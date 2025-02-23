using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Infrastructure.Data.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}
