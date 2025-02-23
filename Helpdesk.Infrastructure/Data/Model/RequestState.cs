using System.ComponentModel.DataAnnotations;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Infrastructure.Data.Model
{
    public class RequestState
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RequestNameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}
