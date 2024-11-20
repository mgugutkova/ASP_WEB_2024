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

		public async Task<IEnumerable<AllAgreementViewModel>> All()
		{
			var agreements = await repository.All<Agreement>()
				.Where(a => a.IsDeleted == false)
				.Select(c => new AllAgreementViewModel()
				{
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

        public async Task<AddAgreementViewModel> EditAgreementAsync(int id)
        {
			var agreement = await repository.All<Agreement>()
				.Where(a=> a.Id == id)
				.Select( x=> new AddAgreementViewModel()
				{
					GoodName = x.GoodName,
					Description = x.Description,
					Price = x.Price,
					Duration = x.Duration,
					StartDate = x.StartDate,
					EndDate = x.EndDate,
					ReturnPrice = x.ReturnPrice,
					UserId = x.UserId
				})
				.FirstOrDefaultAsync();

			return agreement;
        }

        public async Task<IEnumerable<AgreementStateViewModel>> GetStates()
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

     
    }
}
