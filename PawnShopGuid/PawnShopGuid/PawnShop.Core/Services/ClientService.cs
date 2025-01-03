using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.Client;
using PawnShop.Core.Models.User;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;
using System.Data;
using static PawnShop.Core.Constants.AdminConstants;


namespace PawnShop.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public ClientService(
            IRepository _repository,
            UserManager<ApplicationUser> _userManager
            )
        {
            repository = _repository;
            userManager = _userManager;
        }


        public async Task<bool> ClientHasAgreementAsync(string userId)
        {
            var isExistAgreements = await repository.AllReadOnly<Agreement>()
                  .AnyAsync(c => c.UserId == userId);

            if (isExistAgreements)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> CreateClientAsync(string userId, string phoneNumber, string address)
        {
            //todo    check phoneNumber unique

            try
            {
                await repository.AddAsync(new Client()
                {
                    UserId = userId,
                    PhoneNumber = phoneNumber,
                    Address = address
                });

                await repository.SaveChangesAsync();

                var newClient = await userManager.FindByIdAsync(userId);

                if (newClient != null)
                {
                    await userManager.AddToRoleAsync(newClient, UserRole);
                }
            }
            catch (Exception ex) 
            {
                return false;
            }
            return true;
  
        }



        public async Task<bool> ExistClientIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

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
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }
            var IsExistClientPhoneNumber = await repository.AllReadOnly<Client>()
             .AnyAsync(c => c.PhoneNumber == phoneNumber);

            if (IsExistClientPhoneNumber)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<AllAgreementViewModel>> GetClientAgreementAsync(string userId)
        {
            var agreements = await repository.All<Agreement>()
                  .Where(c => c.UserId == userId)
                  .Where(c => c.IsDeleted == false)
                  .Select(a => new AllAgreementViewModel()
                  {
                      Id = a.Id.ToString(),
                      GoodName = a.GoodName,
                      Description = a.Description ?? string.Empty,
                      Price = a.Price,
                      ReturnPrice = a.ReturnPrice,
                      Duration = a.Duration,
                      Ainterest = a.Ainterest,
                      StartDate = a.StartDate,
                      EndDate = a.EndDate,
                      AgrreementStates = a.AgrreementStates.Name,
                      AgrreementStateId = a.AgrreementStateId
                  })
                  .ToListAsync();

            return agreements;
        }

        public async Task<AllUsersViewModel> DeleteClientAsync(string userId)
        {
            var user = await repository.AllReadOnly<ApplicationUser>()
               .Where(x => x.Id == userId)
               .Select(c => new AllUsersViewModel()
               {
                   UserId = c.Id,
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   Email = c.Email ?? string.Empty,
                   PhoneNumber = c.Client != null ? c.Client.PhoneNumber : string.Empty,
                   IsClient = c.Client != null
               })
               .FirstOrDefaultAsync();

            return user;
        }

        public async Task DeleteClientConfirmendAsync(string userId)
        {
            var client = await repository.All<Client>()
                .Where(x => x.UserId == userId)
                .Where(x => x.IsDeleted == false)
                 .FirstOrDefaultAsync();

            client.IsDeleted = true;

            await repository.SaveChangesAsync();
        }

        public async Task<ClientViewModel> GetClientAsync(string userId)
        {
            var client = await repository.AllReadOnly<Client>()
                .Where(x => x.UserId == userId)
                .Where(x => x.IsDeleted == false)
                .Select(c => new ClientViewModel()
                {
                    Id = c.Id.ToString()
                })
                .FirstOrDefaultAsync();

            return client;
        }
    }
}
