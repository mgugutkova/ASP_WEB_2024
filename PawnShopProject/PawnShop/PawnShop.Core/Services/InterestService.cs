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

        public async Task AddInterestAsync(int agreementId, string userId)
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

        public async Task<AllInterestViewModel> DeleteInterestAsync(int id)
        {
            var model = await repository.AllReadOnly<Interest>()
             .Where(a => a.Id == id)
             .Where(a => a.IsDeleted == false)
             .Select(s => new AllInterestViewModel()
             {
                 Id = s.Id,
                 ValueInterest = s.ValueInterest,
                 GoodName = s.Agreement.GoodName,
                 EndDate = s.Agreement.EndDate,
                 DateInterest = s.DateInterest,
                 UserLastName = s.Account.LastName,
                 UserFirstName = s.Account.FirstName,
                 EndDateChanged = s.Agreement.EndDate.AddDays(-s.Agreement.Duration)
             })
             .FirstOrDefaultAsync();

            if (model == null)
            {
                //TODO
            }

            return model;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var interest = await repository.All<Interest>()
              .Where(a => a.Id == id)
              .Where(a => a.IsDeleted == false)
              .FirstOrDefaultAsync();

            interest.IsDeleted = true;

            var agreement = await repository.All<Agreement>()
                 .Where(a => a.Id == interest.AgreementId)
                 .Where(a => a.IsDeleted == false)
                 .FirstOrDefaultAsync();

            agreement.EndDate = agreement.EndDate.AddDays(-agreement.Duration);

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllInterestViewModel>> GetAllInterestsAsync(int agreementId)
        {
            var interests = await repository.All<Interest>()
               .Where(a => a.AgreementId == agreementId)
               .Where(x => x.IsDeleted == false)
               .Select(i => new AllInterestViewModel()
               {
                   Id = i.Id,
                   AgreementId = agreementId,
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
