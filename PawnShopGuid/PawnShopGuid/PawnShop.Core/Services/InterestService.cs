using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Interest;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Core.Services
{
    public class InterestService : IInterestService
    {
        private readonly IRepository repository;
        private readonly ILogger logger;

        public InterestService(
            IRepository _repository,
            ILogger<InterestService> _logger)
        {
            repository = _repository;
            logger = _logger;
        }

        public async Task AddInterestAsync(Guid agreementId, string userId)
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
                ValueInterest = agreement.Ainterest,
                DateInterest = DateTime.UtcNow,
                UserId = userId
            });

            await repository.SaveChangesAsync();
        }

        public async Task<AllInterestViewModel?> DeleteInterestAsync(Guid? id)
        {
            var interest = await repository.AllReadOnly<Interest>()
             .Where(a => a.Id == id)
             .Where(a => a.IsDeleted == false)
             .Select(s => new AllInterestViewModel()
             {
                 Id = s.Id.ToString(),
                 ValueInterest = s.ValueInterest,
                 GoodName = s.Agreement.GoodName,
                 EndDate = s.Agreement.EndDate,
                 DateInterest = s.DateInterest,
                 UserLastName = s.Account.LastName,
                 UserFirstName = s.Account.FirstName,
                 EndDateChanged = s.Agreement.EndDate.AddDays(-s.Agreement.Duration)
             })
             .FirstOrDefaultAsync();

            return interest;
        }

        public async Task DeleteConfirmedAsync(Guid id)
        {
            var interest = await repository.All<Interest>()
              .Where(a => a.Id == id)
              .Where(a => a.IsDeleted == false)
              .FirstOrDefaultAsync();

            if (interest != null)
            {
                interest.IsDeleted = true;

                var agreement = await repository.All<Agreement>()
                     .Where(a => a.Id == interest.AgreementId)
                     .Where(a => a.IsDeleted == false)
                     .FirstOrDefaultAsync();

                if (agreement != null)
                {
                    agreement.EndDate = agreement.EndDate.AddDays(-agreement.Duration);
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AllInterestViewModel>> GetAllInterestsAsync(Guid agreementId)
        {
            var interests = await repository.All<Interest>()
               .Where(a => a.AgreementId == agreementId)
               .Where(x => x.IsDeleted == false)
               .Select(i => new AllInterestViewModel()
               {
                   Id = i.Id.ToString(),
                   AgreementId = agreementId.ToString(),
                   ValueInterest = i.ValueInterest,
                   DateInterest = i.DateInterest,
                   UserFirstName = i.Account.FirstName,
                   UserLastName = i.Account.LastName,
                   GoodName = i.Agreement.GoodName,
                   EndDate = i.Agreement.EndDate
               })
               .OrderByDescending(x => x.DateInterest)
               .ToListAsync();

            return interests;
        }
    }
}
