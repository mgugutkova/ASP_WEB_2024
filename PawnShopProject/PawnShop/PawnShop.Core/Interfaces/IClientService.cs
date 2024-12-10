using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.Client;
using PawnShop.Core.Models.User;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Core.Interfaces
{
    public interface IClientService
    {
        Task<bool> ExistClientIdAsync(string userId);

        Task<bool> ExistClientPhoneNumberAsync(string phoneNumber);

        Task<bool> ClientHasAgreementAsync(string userId);

        Task CreateClientAsync(string userId, string phoneNumber, string address);

        //  Task<int> GetClientIdAsync(string userId);
        Task<ClientViewModel> GetClientAsync(string userId);
        Task<IEnumerable<AllAgreementViewModel>> GetClientAgreementAsync(string userId);

        Task<AllUsersViewModel> DeleteClientAsync(string userId);
        Task DeleteClientConfirmendAsync(string userId);
    }
}
