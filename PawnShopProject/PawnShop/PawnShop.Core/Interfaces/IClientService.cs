using PawnShop.Core.Models.Client;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Core.Interfaces
{
    public interface IClientService
    {
        Task<bool> ExistClientIdAsync(string userId);

        Task<bool> ExistClientPhoneNumberAsync(string phoneNumber);

        Task<bool> ClientHasContractsAsync(string userId);

        Task CreateClientAsync(string userId, string phoneNumber, string address);

        Task<int?> GetClientIdAsync(string userId);

        Task<BecomeClientFormModel> GetClient();
    }
}
