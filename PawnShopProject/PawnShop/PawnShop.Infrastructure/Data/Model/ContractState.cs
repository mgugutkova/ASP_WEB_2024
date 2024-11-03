using System.ComponentModel.DataAnnotations;

namespace PawnShop.Infrastructure.Data.Model
{
	public class ContractState
	{
		[Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}