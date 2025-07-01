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

        public string? OperatorId { get; set; }

        [ForeignKey(nameof(OperatorId))]
        public ApplicationUser? Operator { get; set; } = null; // който изпълнява заявките

        public string? ManagerId { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public ApplicationUser? Manager { get; set; } = null;  // който close заявките

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


        [MaxLength(CommentMaxLength)]
        public string? Comment { get; set; } = null;

        [MaxLength(CommentMaxLength)]
        public string? Satisfaction { get; set; } = null;

        public byte[] Data { get; set; } = Array.Empty<byte>();
        public string? FileName { get; set; } // напр. "document.pdf"
        public string? ContentType { get; set; } // напр. "application/pdf" или "image/jpeg"


        [Required]
        public bool IsActive { get; set; } = true;
    }
}
