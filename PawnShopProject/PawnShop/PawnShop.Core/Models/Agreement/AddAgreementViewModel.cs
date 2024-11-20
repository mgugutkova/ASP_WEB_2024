using PawnShop.Core.Models.AgreementState;
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
		[Display(Name ="Стока")]
		public string GoodName { get; set; } = string.Empty;

		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = ErrorMessageLength)]
		[Display(Name = "Описание")]
		public string? Description { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		[Display(Name = "Заложна стойност")]
		[Range(PriceMinValue, PriceMaxValue)]
		public decimal Price { get; set; }

		[Required]
		[Column(TypeName = "decimal(18,2)")]
		[Display(Name = "Стойност за връщане")]
		[Range(PriceMinValue, PriceMaxValue)]
		public decimal ReturnPrice { get; set; }


		[Required]
		[Display(Name = "Срок на договора. Лихвата е 10% на ден")]
		[Range(DurationMinValue, DurationMaxValue)]
		public int Duration { get; set; }

		[Required]
		[Display(Name = "Начална дата")]
		public DateTime StartDate { get; set; } = DateTime.Now;


		[Required]
		[Display(Name = "Крайна дата")]
		public DateTime EndDate { get; set; }

		[Required]
		public string UserId { get; set; } = string.Empty;	

		[Required]
		public bool IsDeleted { get; set; } = false;

		[Required]
		public int AgrreementStateId { get; set; }	

		public IEnumerable<AgreementStateViewModel>AgreementsStates { get; set; } = new List<AgreementStateViewModel>();

	}
}
