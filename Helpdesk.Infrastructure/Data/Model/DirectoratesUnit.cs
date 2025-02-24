
using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Infrastructure.Data.Model
{
    public class DirectoratesUnit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DirectorateNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
