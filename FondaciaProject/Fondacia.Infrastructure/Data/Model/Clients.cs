using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fondacia.Infrastructure.Data.Model
{
    public class Clients
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Nicname { get; set; } = string.Empty;

        [Required]
        public string Contract { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int FoodId { get; set; } 

        [Required]
        public FoodType FoodType { get; set; } = null!;

        public string? Notice { get; set; } = null;

        [Required]
        public bool IsActive { get; set; } = true;

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

        public byte[]? Data { get; set; } = Array.Empty<byte>();
        public string? FileName { get; set; } // напр. "document.pdf"
        public string? ContentType { get; set; } // напр. "application/pdf" или "image/jpeg"


        public ICollection<Activities> Activities { get; set; } = new HashSet<Activities>();
        public ICollection<VacationClients> Vacations { get; set; } = new HashSet<VacationClients>();
    }

}
