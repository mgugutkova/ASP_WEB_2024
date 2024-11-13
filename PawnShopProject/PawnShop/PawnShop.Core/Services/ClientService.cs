using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Client;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;
using System.Security.Claims;

namespace PawnShop.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository repository;
		
		public ClientService(IRepository _repository)
        {
            repository = _repository;           
        }


        public Task<bool> ClientHasContractsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateClientAsync(string userId, string phoneNumber, string address)
        {
            await repository.AddAsync(new Client()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
                Address = address
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistClientIdAsync(string userId)
        {
            var IsExistClientId = await repository.AllReadOnly<Client>()
                .AnyAsync(c => c.UserId == userId);

            if (IsExistClientId)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExistClientPhoneNumberAsync(string phoneNumber)
        {
            var IsExistClientPhoneNumber = await repository.AllReadOnly<Client>()
             .AnyAsync(c => c.PhoneNumber == phoneNumber);

            if (IsExistClientPhoneNumber)
            {
                return true;
            }
            return false;
        }

        public Task<BecomeClientFormModel?> GetClient()
        {
			//var user = userManager.Users.FirstOrDefault();

			//var client = repository.AllReadOnly<Client>()
   //             .Where(x => x.UserId == user.Id)
   //             .Select(c => new BecomeClientFormModel()
   //             {
   //                 PhoneNumber = c.PhoneNumber,
   //                 Address = c.Address
   //             })
   //             .FirstOrDefaultAsync();
              

   //         if (client == null)
   //         {
   //             return null;
   //         }

            return null;
        }
		
		public async Task<int?> GetClientIdAsync(string userId)
        {
            var getUserId = await repository.AllReadOnly<Client>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (getUserId == null)
            {
                return null;
            }

            return getUserId.Id;
        }
    }
}
