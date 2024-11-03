using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
    public class Contract
	{
		[Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(GoodNameMaxLength)]
		public string GoodName { get; set; } = string.Empty;
	
		public string? Description { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Price { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		public decimal ReturnPrice { get; set; }


		[Required]
		public int Duration { get; set; }

        [Required]
        public DateTime StartDate { get; set; }


		[Required]
		public DateTime EndDate { get; set; }

        [Required]
        public int ClientId { get; set; } 

		[Required]
		[ForeignKey(nameof(ClientId))]
		public Client Client { get; set; } = null!;
		
		public string OperatorId { get; set; } = string.Empty;
		
		[ForeignKey(nameof(OperatorId))]
		public IdentityUser Operator { get; set; } = null!;

		[Required]
		public bool IsDeleted { get; set; } = false;

		[Required]
		public int ContractStateId { get; set; }

		[Required]
		[ForeignKey(nameof(ContractStateId))]
		public ContractState ContractState { get; set; } = null!;

		public IEnumerable<Interest> Interests { get; set; } = new HashSet<Interest>();
    }

}
