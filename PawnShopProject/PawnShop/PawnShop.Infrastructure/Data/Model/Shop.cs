using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawnShop.Infrastructure.Data.Model
{
	public class Shop
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ContractId { get; set; }

		[Required]
		[ForeignKey(nameof(ContractId))]
		public Contract Contract { get; set; } = null!;

		[Column(TypeName = "decimal(18,2)")]
		public decimal SellPrice { get; set; }

		public DateTime SoldDate { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

    }
}
