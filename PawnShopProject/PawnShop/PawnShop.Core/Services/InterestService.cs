using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Interest;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Core.Services
{
    public class InterestService : IInterestService
    {
        private readonly IRepository repository;

        public InterestService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddInterestAsync(int agreementId, string userId, decimal valueInterest)
        {
            var agreement = await repository.All<Agreement>()
                .Where(a => a.Id == agreementId)
                .Where(x => x.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (agreement == null)
            {
                throw new ArgumentException("Bad request");
            }

            agreement.EndDate = agreement.EndDate.AddDays(agreement.Duration);       

            await repository.AddAsync(new Interest()
            {
                AgreementId = agreementId,
                ValueInterest = valueInterest,
                DateInterest = DateTime.UtcNow,
                UserId = userId
            });

            await repository.SaveChangesAsync();
        }

        public Task<IEnumerable<AllInterestViewModel>> GetAllInterestsAsync(int agreementId)
        {
            throw new NotImplementedException();
        }
    }
}
