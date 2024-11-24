using Microsoft.AspNetCore.Identity;
using PawnShop.Core.Models.AgreementState;
using PawnShop.Infrastructure.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Core.Models.Agreement
{
    public class AddAgreementViewModel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(GoodNameMaxLength, MinimumLength = GoodNameMinLength, ErrorMessage = ErrorMessageLength)]
		[Display(Name ="Name of good")]
		public string GoodName { get; set; } = string.Empty;

		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = ErrorMessageLength)]
		[Display(Name = "Description (optional)")]
		public string? Description { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		[Display(Name = "Price")]
		[Range(PriceMinValue, PriceMaxValue)]
		public decimal Price { get; set; }

		
		[Column(TypeName = "decimal(18,2)")]
		[Display(Name = "Return Price - will be calculated automatically")]	
		public decimal ReturnPrice { get; set; }


		[Required]
		[Display(Name = "Duration. 30% interest per day")]
		[Range(DurationMinValue, DurationMaxValue)]
		public int Duration { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Interest")]
        public decimal Ainterest { get; set; }

        [Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; } = DateTime.Now;

		
		[Display(Name = "End Date")]
		public DateTime EndDate { get; set; }		
     
        public string UserId { get; set; } = string.Empty;
        public string UserFirstName { get; set; } = string.Empty;
        public string UserLastName { get; set; } = string.Empty;

		[Required]
		public int AgrreementStateId { get; set; }	

		public string AgreementState {  get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
		public IEnumerable<AgreementStateViewModel>AgreementsStates { get; set; } = new List<AgreementStateViewModel>();

  
	}
}
