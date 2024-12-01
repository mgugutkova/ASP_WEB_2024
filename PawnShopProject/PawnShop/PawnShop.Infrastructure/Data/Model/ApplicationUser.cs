using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
    public class ApplicationUser : IdentityUser
	{
		[Required]
		[MaxLength(FirstNameMaxLength)]
		[PersonalData]
		public string FirstName { get; set; } = string.Empty;


		[Required]
		[MaxLength(LastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;
	}
}
