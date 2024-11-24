using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
	public class Agreement
	{
		[Key]
        [Comment("Идентификатор на договора")]
        public int Id { get; set; }

		[Required]
		[MaxLength(GoodNameMaxLength)]
		[Comment("Стока")]
		public string GoodName { get; set; } = string.Empty;

        [Comment("Описание")]
        public string? Description { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
        [Comment("Заложна стойност")]
        public decimal Price { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
        [Comment("Стойност за връщане")]
        public decimal ReturnPrice { get; set; }

		[Required]
        [Comment("Срок на договора")]
        public int Duration { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Comment("Лихва")]
        public decimal Ainterest { get; set; }

        [Required]
        [Comment("Начална дата на договора")]
        public DateTime StartDate { get; set; }

		[Required]
        [Comment("Крайна дата на договора")]
        public DateTime EndDate { get; set; }

		[Required]
        [Comment("Идентификатор на потребителя")]
        public string UserId { get; set; } = string.Empty;
		
		[ForeignKey(nameof(UserId))]
		public ApplicationUser Account { get; set; } = null!;

		[Required]
        [Comment("SoftDeleted")]
		[DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

		[Required]
		[Comment("Статус на договора")]
		[DefaultValue(1)]
		public int AgrreementStateId { get; set; } = 1;

		[Required]
		[ForeignKey(nameof(AgrreementStateId))]
		public AgreementState AgrreementStates { get; set; } = null!;

		public IEnumerable<Interest> Interests { get; set; } = new HashSet<Interest>();
    }

}
