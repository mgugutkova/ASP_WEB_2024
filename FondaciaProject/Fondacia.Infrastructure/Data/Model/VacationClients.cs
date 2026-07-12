using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fondacia.Infrastructure.Data.Model
{
    public class VacationClients
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(ClientId))]
        public Clients Client { get; set; } = null!;

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        public string? Notice { get; set; } = null;

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
    }

}
