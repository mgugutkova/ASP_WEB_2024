using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Interfaces;
using PawnShop.Core.Models.Agreement;
using PawnShop.Core.Models.AgreementState;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.Data.Repo;

namespace PawnShop.Core.Services
{
    public class AgreementService : IAgreementService
    {
        private readonly IRepository repository;

        public AgreementService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<AllAgreementViewModel>> AllAsync()
        {
            var agreements = await repository.AllReadOnly<Agreement>()
                .Where(a => a.IsDeleted == false)
                .Select(c => new AllAgreementViewModel()
                {
                    Id = c.Id,
                    GoodName = c.GoodName,
                    Description = c.Description,
                    Price = c.Price,
                    ReturnPrice = c.ReturnPrice,
                    Duration = c.Duration,
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    AgrreementStates = c.AgrreementStates.Name

                })
                .ToListAsync();

            return agreements;
        }

        public async Task CreateAgreementAsync(string userId,
            string GoodName,
            string Description,
            decimal Price,
            int Duration
            )
        {

            DateTime EndDate = DateTime.UtcNow.AddDays(Duration);

            decimal ReturnPrice = Price + (Duration * 0.1M);

            await repository.AddAsync(new Agreement()
            {
                GoodName = GoodName,
                Description = Description,
                Price = Price,
                Duration = Duration,
                StartDate = DateTime.UtcNow,
                EndDate = EndDate,
                ReturnPrice = ReturnPrice,
                UserId = userId,
                AgrreementStateId = 1
            });

            await repository.SaveChangesAsync();
        }

        public async Task EditAgreementAsync(int id, AddAgreementViewModel model)
        {
            var agreement = await repository.All<Agreement>()
                .Where(a => a.Id == id)
                .Where(a => a.IsDeleted == false)
                .FirstOrDefaultAsync();
                

            if (agreement != null)
            {
                agreement.GoodName = model.GoodName;
                agreement.Description = model.Description;
                agreement.Price = model.Price;
                agreement.ReturnPrice = model.ReturnPrice;
                agreement.Duration = model.Duration;
                agreement.StartDate = model.StartDate;
                agreement.EndDate = model.StartDate.AddDays(model.Duration);
                agreement.AgrreementStateId = model.AgrreementStateId;            

                await repository.SaveChangesAsync();
            }
        }

        public async Task<AddAgreementViewModel?> GetAgreementAsync(int? id)
        {
            var model = await repository.AllReadOnly<Agreement>()
                .Where(a => a.Id == id)
                .Where(d => d.IsDeleted == false)
                .Select(x => new AddAgreementViewModel()
                {
                    Id = x.Id,
                    GoodName = x.GoodName,
                    Description = x.Description,
                    Price = x.Price,
                    Duration = x.Duration,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ReturnPrice = x.ReturnPrice,
                    AgreementState = x.AgrreementStates.Name,
                    UserId = x.UserId,
                    AgrreementStateId = x.AgrreementStateId,
                    UserFirstName = x.Account.FirstName ?? string.Empty,
                    UserLastName = x.Account.LastName ?? string.Empty                   

                })
                .FirstOrDefaultAsync();

            if (model != null)
            {
                model.AgreementsStates = await GetStatesAsync();
            }

            return model;
        }

        public async Task<IEnumerable<AgreementStateViewModel>> GetStatesAsync()
        {
            var states = await repository.AllReadOnly<AgreementState>()
               .Select(x => new AgreementStateViewModel
               {
                   Name = x.Name,
                   Id = x.Id,
               })
               .ToListAsync();

            return states;
        }

        public async Task<bool> IsAgreementExistAsync(int id)
        {
            return await repository.AllReadOnly<Agreement>()
                .AnyAsync(a=> a.Id == id);
           
        }
    }
}
