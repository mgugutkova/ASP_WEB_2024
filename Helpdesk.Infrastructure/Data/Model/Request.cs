using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Helpdesk.Infrastructure.Constants.DataConstants;

namespace Helpdesk.Infrastructure.Data.Model
{
    public class Request
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser UserMI { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty!;


        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime? EndDate { get; set; }

        [Required]
        public int RequestStateId { get; set; }


        [Required]
        [ForeignKey(nameof(RequestStateId))]
        public RequestState RequestState { get; set; } = null!;

        public Guid OperatorId { get; set; }

        [ForeignKey(nameof(OperatorId))]
        public Operator? Operator { get; set; } = null;


        [MaxLength(CommentMaxLength)]
        public string? Comment { get; set; } = null;

        [Required]
        public bool IsActive { get; set; }
    }
}
