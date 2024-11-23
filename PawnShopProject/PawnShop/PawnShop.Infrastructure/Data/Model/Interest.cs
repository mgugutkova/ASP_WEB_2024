using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawnShop.Infrastructure.Data.Model
{
	public class Interest
	{
		[Key]
        [Comment("Идентификатор на лихва")]
        public int Id { get; set; }

		[Required]
        [Comment("Идентификатор на договора")]
        public int AgreementId { get; set; }

        [Required]
        [ForeignKey(nameof(AgreementId))]
        public Agreement Agreement { get; set; } = null!;

		[Required]
		[Column(TypeName = "decimal(18,2)")]
        [Comment("Стойност на лихвата")]
        public decimal ValueInterest { get; set; }

		[Required]
        [Comment("Дата на внасяне на лихвата")]
        public DateTime DateInterest { get; set; }

		[Required]
        [Comment("Идентификатор на потребителя")]
        public string UserId { get; set; } = string.Empty;

		[ForeignKey(nameof(UserId))]
		public ApplicationUser Account { get; set; } = null!;

        [Required]
        [Comment("SoftDeleted")]
        public bool IsDeleted { get; set; } = false;
	}
}