using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Agreement;
using PawnShop.Infrastructure.Data.Model;
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

        public async Task<IEnumerable<AllAgreementViewModel>>GetClientAgreementAsync(string userId)
        {
            var agreements = await repository.All<Agreement>()
                  .Where(c => c.UserId == userId)
                  .Where(c => c.IsDeleted == false)
                  .Select(a => new AllAgreementViewModel()
                  {
                      Id = a.Id,
                      GoodName = a.GoodName,
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

        //public async Task<BecomeClientFormModel?> GetClient()
        //{
        //    //var user = userManager.Users.FirstOrDefault();
        //    var user = await userManager.GetUserAsync(this.User);

        //    var client = repository.AllReadOnly<Client>()
        //                 .Where(x => x.UserId == user.Id)
        //                 .Select(c => new BecomeClientFormModel()
        //                 {
        //                     PhoneNumber = c.PhoneNumber,
        //                     Address = c.Address
        //                 })
        //                 .FirstOrDefaultAsync();


        //    if (client == null)
        //    {
        //        return null;
        //    }

        //    return null;
        //}

        public async Task<int> GetClientIdAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return 0;
            }

            var getUserId = await repository.AllReadOnly<Client>()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (getUserId == null)
            {
                return 0;
            }

            return getUserId.Id;
        }
    }
}
