
namespace PawnShop.Core.Models.Agreement
{
    public class AgreementServiceQueryModel
    {

        public int TotalAgreementCount { get; set; }

        public IEnumerable<AgreementServiceModel> AgreementsList { get; set; } =
            new HashSet<AgreementServiceModel>();

    }
}
