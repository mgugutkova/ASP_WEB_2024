using PawnShop.Core.Enumerations;
using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.AgreementState;

namespace PawnShop.Core.Interfaces
{
    public interface IAgreementService
	{
		Task CreateAgreementAsync(string userId, string GoodName, string Description,decimal Price,
			int Duration);

		Task<IEnumerable<AgreementStateViewModel>> GetStatesAsync();

		Task<IEnumerable<AllAgreementViewModel>> AllAsync();
		Task<IEnumerable<AllAgreementViewModel>> AllAgreementsAsync(string userId);

		Task<bool> IsAgreementExistAsync(int id);
		Task<bool> IsInterestExistAsync(int agreementId);

		Task <AddAgreementViewModel?> GetAgreementAsync(int? id);

		Task <AllAgreementViewModel?> FindAgreementAsync(int? id);

		Task EditAgreementAsync(int id, AddAgreementViewModel model);

		Task <AllAgreementViewModel?>DeleteAgreementAsync(int? id);

		Task DeleteConfirmedAsync(int id);

		Task<AgreementServiceQueryModel> AllAsync(
			int states = 0,
			string? searchTerm = null,
			AgreementSorting sorting = AgreementSorting.Newest,
			int currentPage = 1,
			int agreementsPerPage = 1
			);

		Task<IEnumerable<string>> AllStatesNamesAsync();
    }
}
