using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fondacia.Infrastructure.Data.Model
{
    public class Personnel
    {
        [Key]
        public Guid Id { get; set; }

        //[Required]
        //public Clients Client { get; set; } = null!;

        [Required]
        public string FullName { get; set; }= string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;
        public string? Notice { get; set; } = null;

        [Required]
        public bool IsActive { get; set; } = true;

        public string? IdentityUserId { get; set; }= null;

        [ForeignKey(nameof(IdentityUserId))]
        public IdentityUser? IdentityUser { get; set; } = null;

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

        public byte[]? ProfilePhoto { get; set; }
        public string? ProfilePhotoContentType { get; set; }




        public ICollection<Ateliers> Ateliers { get; set; } = new List<Ateliers>();
        public ICollection<VacationPersonnel> Vacations { get; set; } = new List<VacationPersonnel>();
    }

}
