using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.AgreementState;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Core.Interfaces
{
	public interface IAgreementService
	{
		Task CreateAgreementAsync(string userId, string GoodName, string Description,decimal Price,
			int Duration);

		Task<IEnumerable<AgreementStateViewModel>> GetStatesAsync();

		Task<IEnumerable<AllAgreementViewModel>> AllAsync();

		Task<bool> IsAgreementExistAsync(int id);

		Task <AddAgreementViewModel?> GetAgreementAsync(int? id);
		Task <AllAgreementViewModel?> FindAgreementAsync(int? id);

		Task EditAgreementAsync(int id, AddAgreementViewModel model);

	}
}
