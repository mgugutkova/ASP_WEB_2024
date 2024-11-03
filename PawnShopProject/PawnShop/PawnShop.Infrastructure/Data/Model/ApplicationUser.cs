using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Infrastructure.Data.Model
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = string.Empty;


		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = string.Empty;
	}
}
