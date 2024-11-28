
using PawnShop.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PawnShop.Core.Models.Agreement
{
    public class AllAgreementQueryViewModel
    {
        public  int AgreementPerPage { get; set; } = 3;

        public string State { get; set; } = string.Empty;

        [Display(Name ="Search by text")]
        public string SearchItem { get; set; } = null!;

        public AgreementSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int TotalAgreementCount { get; set; }

        public IEnumerable<string> AgreementStates { get; set; } = null!;

        public IEnumerable<AgreementServiceModel> Agreements { get; set; } = new HashSet<AgreementServiceModel>();
    }
}
