
using PawnShop.Core.Models.Interest;

namespace PawnShop.Core.Interfaces
{
    public interface IInterestService
    {      
        Task AddInterestAsync(int agreementId, string userId, decimal valueInterest);

        Task<IEnumerable<AllInterestViewModel>> GetAllInterestsAsync(int agreementId);
    }
}
