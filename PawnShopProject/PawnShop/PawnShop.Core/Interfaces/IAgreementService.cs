using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.AgreementState;

namespace PawnShop.Core.Interfaces
{
	public interface IAgreementService
	{
		Task CreateAgreementAsync(string userId, 
			string GoodName,
			string Description,
			decimal Price,
			int Duration);

		Task<IEnumerable<AgreementStateViewModel>> GetStates();

		Task<AddAgreementViewModel> EditAgreementAsync(int id);

		Task<IEnumerable<AllAgreementViewModel>> All();
	}
}
