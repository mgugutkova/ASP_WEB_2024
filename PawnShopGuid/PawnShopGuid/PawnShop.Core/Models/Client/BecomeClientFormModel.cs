using System.ComponentModel.DataAnnotations;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Core.Models.Client
{
	public class BecomeClientFormModel
	{

		[Required]
		[StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = ErrorMessageLength)]	
		[Display(Name = "Phone number")]
		public string PhoneNumber { get; set; } = string.Empty;

		[Required]		
		[Display(Name = "Address")]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = ErrorMessageLength)]
        public string Address { get; set; } = string.Empty;

	}
}
