using PawnShop.Core.Models.Interest;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PawnShop.Infrastructure.Data.DataConstants;

namespace PawnShop.Core.Models.Agreement
{
    public class AgreementServiceModel
    {

        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(GoodNameMaxLength, MinimumLength = GoodNameMinLength, ErrorMessage = ErrorMessageLength)]
        [Display(Name = "Name of goods")]
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

        public string FirstName { get; set; } = string.Empty ;
        public string LastName { get; set; } = string.Empty ;
        public string AgreementState {  get; set; } = string.Empty;
        public int AgrreementStateId {  get; set; }
      
    }
}