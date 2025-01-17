using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawnShop.Infrastructure.Data.Model
{
	public class Shop
	{
		[Key]
        [Comment("Идентификатор на стоката в магазин")]
        public Guid Id { get; set; } = new Guid();

        [Required]
        [Comment("Име на стоката")]
        public string Name { get; set; } = string.Empty;

        [Comment("Допълнително описание - не е задължително")]
        public string? Description { get; set; } = string.Empty;

		[Required]
        [Comment("Идентификатор на договора")]
        public Guid AgreementId { get; set; }

		[Required]
		[ForeignKey(nameof(AgreementId))]
		public Agreement Agreement { get; set; } = null!;


		[Column(TypeName = "decimal(18,2)")]
        [Comment("Цена на стоката")]
        public decimal SellPrice { get; set; }

        [Comment("Дата на продажба на стоката")]
        public DateTime? SoldDate { get; set; }

        
        [Required]
        [Comment("SoftDeleted")]
        public bool IsDeleted { get; set; } = false;

    }
}
