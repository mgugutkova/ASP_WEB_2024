using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
	[Index(nameof(PhoneNumber), IsUnique = true)]
	[Index(nameof(UserId), IsUnique = true)]
	public class Client
	{
		[Key]
        public Guid Id { get; set; } = new Guid();

        [Required]
		[MaxLength(PhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = string.Empty;		

        [Required]     
        public string Address { get; set; } = string.Empty;

        [Required]
		public string UserId { get; set; } = string.Empty;

		[Required]
		[ForeignKey(nameof(UserId))]	
		public ApplicationUser User { get; set; } = null!;

		public IEnumerable<Agreement> Contracts { get; set; } = new HashSet<Agreement>();

        [Required]
        public bool IsDeleted { get; set; } = false;

    }
}
