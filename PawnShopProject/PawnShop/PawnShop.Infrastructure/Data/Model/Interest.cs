using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawnShop.Infrastructure.Data.Model
{
	public class Interest
	{
		[Key]
        public int Id { get; set; }

		[Required]
		public int ContractId { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ValueInterest { get; set; }

		[Required]
		public DateTime DateInterest { get; set; }

		public string OperatorId { get; set; } = string.Empty;

		[ForeignKey(nameof(OperatorId))]
		public IdentityUser Operator { get; set; } = null!;

		[Required]
		public bool IsDeleted { get; set; } = false;
	}
}