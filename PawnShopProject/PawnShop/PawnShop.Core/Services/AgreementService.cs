using Microsoft.EntityFrameworkCore;
using PawnShop.Core.Enumerations;
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
                    AgrreementStates = c.AgrreementStates.Name,
                    Ainterest = c.Ainterest,
                    AgrreementStateId = c.AgrreementStateId

                })
                .ToListAsync();

            return agreements;
        }

        public async Task<AgreementServiceQueryModel> AllAsync(
            int states,
            string? searchTerm = null,
            AgreementSorting sorting = AgreementSorting.Newest,
            int currentPage = 1,
            int agreementsPerPage = 1)
        {
            var agreementToShow = repository.AllReadOnly<Agreement>()
                .Where(a => a.IsDeleted == false);

            // if (!string.IsNullOrEmpty(states))
            if (states != 0)
            {
                agreementToShow = agreementToShow
                    .Where(c => c.AgrreementStates.Id == states);
            }

            if (searchTerm != null)
            {
                string normalizedSearchString = searchTerm.ToLower();
                agreementToShow = agreementToShow
                    .Where(h => (h.GoodName.ToLower().Contains(normalizedSearchString) ||
                        h.Description!.ToLower().Contains(normalizedSearchString) ||
                        h.Account.FirstName.ToLower().Contains(normalizedSearchString) ||
                        h.Account.LastName.ToLower().Contains(normalizedSearchString)
                        ));
            }

            agreementToShow = sorting switch
            {
                AgreementSorting.Newest =>
                agreementToShow.OrderByDescending(h => h.Id),

                AgreementSorting.Price =>
            agreementToShow.OrderByDescending(h => h.Price),

                _ => agreementToShow.OrderByDescending(a => a.Id)

            };

            var agreements = await agreementToShow
                .Skip((currentPage - 1) * agreementsPerPage)
                .Take(agreementsPerPage)
                .Select(a => new AgreementServiceModel()
                {
                    Id = a.Id,
                    GoodName = a.GoodName,
                    Description = a.Description,
                    Price = a.Price,
                    ReturnPrice = a.ReturnPrice,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    FirstName = a.Account.FirstName,
                    LastName = a.Account.LastName,
                    Duration = a.Duration,
                    Ainterest = a.Ainterest,
                    AgreementState = a.AgrreementStates.Name,
                    AgrreementStateId = a.AgrreementStates.Id
                })
                .ToListAsync();

            int totalAgreements = await agreementToShow.CountAsync();

            return new AgreementServiceQueryModel()
            {
                TotalAgreementCount = totalAgreements,
                AgreementsList = agreements

            };
        }

        public async Task<IEnumerable<string>> AllStatesNamesAsync()
        {
            return await repository.AllReadOnly<AgreementState>()
                .Select(a => a.Name)
                .ToListAsync();
        }

        public async Task CreateAgreementAsync(string userId,
            string GoodName,
            string Description,
            decimal Price,
            int Duration
            )
        {

            DateTime EndDate = DateTime.UtcNow.AddDays(Duration);

            decimal ReturnPrice = Price + (Duration * 0.3M);

            decimal AgreementInteres = Duration * 0.3M;

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
                AgrreementStateId = 1,
                Ainterest = AgreementInteres
            });

            await repository.SaveChangesAsync();
        }

        public async Task<AllAgreementViewModel?> DeleteAgreementAsync(int? id)
        {
            var model = await repository.AllReadOnly<Agreement>()
             .Where(a => a.Id == id)
             .Where(a => a.IsDeleted == false)
             .Select(s => new AllAgreementViewModel()
             {
                 Id = s.Id,
                 GoodName = s.GoodName,
                 Price = s.Price,
                 EndDate = s.EndDate,
                 FirstName = s.Account.FirstName,
                 LastName = s.Account.LastName,
                 AgrreementStateId = s.AgrreementStateId
             })
             .FirstOrDefaultAsync();

            return model;
        }

        public async Task DeleteConfirmedAsync(int id)
        {
            var agreement = await repository.All<Agreement>()
            .Where(a => a.Id == id)
            .Where(a => a.IsDeleted == false)
            .FirstOrDefaultAsync();

            if (agreement == null)
            {
                return;
            }
            agreement.IsDeleted = true;

            var interests = await repository.All<Interest>()
                .Where(i => i.AgreementId == id)
                .ToListAsync();

            if (interests.Any())
            {
                foreach (var interest in interests)
                {
                    interest.IsDeleted = true;
                }
            }
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
                agreement.ReturnPrice = model.Price + (model.Duration * 0.3M);
                agreement.Duration = model.Duration;
                agreement.StartDate = model.StartDate;
                agreement.EndDate = model.StartDate.AddDays(model.Duration);
                agreement.AgrreementStateId = model.AgrreementStateId;
                agreement.Ainterest = model.Duration * 0.3M;


                if (agreement.AgrreementStateId == 5)
                {
                    var goodsForShop = new Shop
                    {
                        AgreementId = agreement.Id,
                        SellPrice = agreement.Price + (agreement.Price * 0.1M),
                        Name = agreement.GoodName,
                        Description = agreement.Description
                    };
                    await repository.AddAsync(goodsForShop);
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<AllAgreementViewModel?> FindAgreementAsync(int? id)
        {
            var model = await repository.AllReadOnly<Agreement>()
                .Where(a => a.Id == id)
                .Where(d => d.IsDeleted == false)
                .Select(x => new AllAgreementViewModel()
                {
                    Id = x.Id,
                    GoodName = x.GoodName,
                    Description = x.Description,
                    Price = x.Price,
                    Duration = x.Duration,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ReturnPrice = x.ReturnPrice,
                    UserId = x.UserId,
                    Ainterest = x.Ainterest

                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<AddAgreementViewModel?> GetAgreementAsync(int? id)
        {
            var model = await repository.All<Agreement>()
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
                    UserLastName = x.Account.LastName ?? string.Empty,
                    Ainterest = x.Ainterest
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
                .AnyAsync(a => a.Id == id);

        }
    }
}
