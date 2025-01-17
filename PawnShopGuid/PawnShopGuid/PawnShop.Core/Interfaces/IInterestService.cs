
using PawnShop.Core.Models.Interest;

namespace PawnShop.Core.Interfaces
{
    public interface IInterestService

    {      
        Task AddInterestAsync(Guid agreementId, string userId);

        Task<IEnumerable<AllInterestViewModel>> GetAllInterestsAsync(Guid agreementId);

        Task<AllInterestViewModel?> DeleteInterestAsync(Guid? id);

        Task DeleteConfirmedAsync(Guid id);
    }

}
