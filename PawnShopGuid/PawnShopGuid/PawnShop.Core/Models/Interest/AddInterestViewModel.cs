using PawnShop.Core.Models.Agreement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawnShop.Core.Models.Interest
{
    public class AddInterestViewModel
    {        
        public string? Id { get; set; }
        
        public string AgreementId { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Interest")]
        public decimal ValueInterest { get; set; }
     
        public DateTime DateInterest { get; set; } = DateTime.UtcNow;
     
        public string UserId { get; set; } = string.Empty;

        public AllAgreementViewModel AgreementViewModel { get; set; } = new AllAgreementViewModel();   
    }
}
