
using PawnShop.Core.Models.Interest;

namespace PawnShop.Core.Interfaces
{
    public interface IInterestService

    {      
        Task AddInterestAsync(int agreementId, string userId);

        Task<IEnumerable<AllInterestViewModel>> GetAllInterestsAsync(int agreementId);

        Task<AllInterestViewModel?> DeleteInterestAsync(int? id);

        Task DeleteConfirmedAsync(int id);
    }

}
