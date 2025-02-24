using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Infrastructure.Data.Model
{
    public class Operator
    {
        [Key] 
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser ITUser { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; } = new HashSet<Request>();

        [Required]
        public bool IsActive { get; set; } = true;
    }
}
