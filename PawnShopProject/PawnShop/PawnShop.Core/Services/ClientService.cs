using PawnShop.Core.Interfaces;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository repository;

        public ClientService(IRepository _repository)
        {
            repository = _repository;
        }


        public Task<bool> ClientHasContractsAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task CreateClientAsync(string clientId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistClientIdAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistClientPhoneNumberAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task GetClientIdAsync(string clientId)
        {
            throw new NotImplementedException();
        }
    }
}
