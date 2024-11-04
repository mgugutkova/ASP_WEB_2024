using System.ComponentModel.DataAnnotations;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
	public class ContractState
	{
		[Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(StateNameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}