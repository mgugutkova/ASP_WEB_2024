using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.RequestState;
using Helpdesk.Infrastructure.Data.Model;
using Helpdesk.Infrastructure.Repo;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Core.Services
{
    public class RequestStateService : IRequestStateService
    {
        private readonly IRepository repository;

        public RequestStateService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task AddRequestStateAsync(string name)
        {
            var state = new RequestState
            { 
                Name = name
            };

            await repository.AddAsync(state);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllRequestStateViewModel>> AllRequestStateAsync()
        {
            var states = await repository.All<RequestState>()
                .Select(x => new AllRequestStateViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return states;
        }

        public async Task EditRequestStateAsync(int id, AllRequestStateViewModel model)
        {
            var state = await repository.GetByIdAsync<RequestState>(id);

            if (state != null)
            {
                state.Name = model.Name;
                await repository.SaveChangesAsync();
            }
        }

        public async Task<AllRequestStateViewModel?> FindRequestStateAsync(int? id)
        {
            var state = await repository.All<RequestState>()
                .Where(r => r.Id == id)
                .Select(x => new AllRequestStateViewModel
                { 
                Name= x.Name
                })
                .FirstOrDefaultAsync();

            return state;
        }
    }
}
