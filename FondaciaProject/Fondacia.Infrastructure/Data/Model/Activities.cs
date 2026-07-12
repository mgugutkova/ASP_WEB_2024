using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fondacia.Infrastructure.Data.Model
{
    public class Activities
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(ClientId))]
        public Clients Client { get; set; } = null!;

        [Required]
        public int AteliersId { get; set; }

        [Required]
        [ForeignKey(nameof(AteliersId))]
        public Ateliers Ateliers { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int FoodTypeId { get; set; }

        [Required]
        [ForeignKey(nameof(FoodTypeId))]
        public FoodType FoodType { get; set; } = null!;

        [Required]
        public Guid PersonId { get; set; } = Guid.Empty;

        [Required]
        [ForeignKey(nameof(PersonId))]
        public Personnel Person { get; set; } = null!;

        public Guid? SecondPersonId { get; set; } = null;

        [ForeignKey(nameof(SecondPersonId))]
        public Personnel? SecondPerson { get; set; } = null;

        public int? AttendanceTypeId { get; set; }

        [ForeignKey(nameof(AttendanceTypeId))]
        public AttendanceType? AttendanceType { get; set; } = null;

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

        public string RowColor { get; set; } = "#ffffff";

        [Required]
        public int Week { get; set; }

    }

}
