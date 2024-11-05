namespace PawnShop.Core.Interfaces
{
    public interface IClientService
    {
        Task<bool> ExistClientIdAsync(string clientId);

        Task<bool> ExistClientPhoneNumberAsync(string phoneNumber);

        Task<bool> ClientHasContractsAsync(string clientId);

        Task CreateClientAsync(string clientId, string phoneNumber);

        Task GetClientIdAsync(string clientId);
    }
}
