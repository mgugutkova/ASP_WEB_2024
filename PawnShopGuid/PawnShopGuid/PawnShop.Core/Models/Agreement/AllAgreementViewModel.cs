
using PawnShop.Core.Models.Interest;

namespace PawnShop.Core.Models.Agreement
{
    public class AllAgreementViewModel
    {
        public string? Id { get; set; }
        public string GoodName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
 
        public decimal ReturnPrice { get; set; }

        public decimal Ainterest { get; set; }

        public int Duration { get; set; }
      
        public DateTime StartDate { get; set; }
      
        public DateTime EndDate { get; set; }
      
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
     
        public bool IsDeleted { get; set; } = false;

        public int AgrreementStateId { get; set; }

        public string AgrreementStates { get; set; } = string.Empty ;

        public bool IsInterestExist {  get; set; }

	}
}
