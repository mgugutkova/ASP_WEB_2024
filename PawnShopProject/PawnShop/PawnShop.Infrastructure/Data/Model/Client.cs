using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
    public class Client
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = string.Empty;


		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = string.Empty;

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string UserId { get; set; } = string.Empty;


		[Required]
		[ForeignKey(nameof(UserId))]	
		public IdentityUser User { get; set; } = null!;

		public IEnumerable<Contract> Contracts { get; set; } = new HashSet<Contract>();

    }
}
