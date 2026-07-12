using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fondacia.Infrastructure.Data.Model
{
    public class AttendanceType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string CreatedByUserId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(CreatedByUserId))]
        public IdentityUser CreatedByUser { get; set; } = null!;

        public string? ModifiedByUserId { get; set; } = null;

        [ForeignKey(nameof(ModifiedByUserId))]
        public IdentityUser? ModifiedByUser { get; set; } = null;

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; } = null;

        public ICollection<Activities> Activities { get; set; } = new List<Activities>();
    }

}
