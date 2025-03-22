using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Directorates;
using Helpdesk.Infrastructure.Data.Model;
using Helpdesk.Infrastructure.Repo;
using Microsoft.EntityFrameworkCore;

namespace Helpdesk.Core.Services
{
    public class DirectoratesService : IDirectoratesService
    {
        private readonly IRepository repository;

        public DirectoratesService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddDirectorateAsync(string name)
        {
            var directorate = new DirectoratesUnit
            {
                Name = name
            };

            await repository.AddAsync(directorate);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllDirectoratesViewModel>> AllDirectoratesAsync()
        {
            var directorates = await repository.AllReadOnly<DirectoratesUnit>()
                .Select( d => new AllDirectoratesViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    IsActive = d.IsActive
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return directorates;
        }

        public async Task EditDirectorateAsync(int id, AllDirectoratesViewModel model)
        {
            var directorate = await repository.GetByIdAsync<DirectoratesUnit>(id);

            if (directorate != null) 
            { 
                directorate.IsActive = model.IsActive;
                directorate.Name = model.Name;

                await repository.SaveChangesAsync();
            }

        }

        public async Task<AllDirectoratesViewModel?> FindDirectorateAsync(int? id)
        {
            var directorate = await repository.All<DirectoratesUnit>()
                .Where(x => x.Id == id)
                .Select( d => new AllDirectoratesViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    IsActive = d.IsActive
                })
                .FirstOrDefaultAsync();

            return directorate;
        }

        public async Task<IEnumerable<AllDirectoratesViewModel>> GetDirectoratesActive()
        {
            var directorates_MI =  await repository.AllReadOnly<DirectoratesUnit>()
                .Where(x => x.IsActive == true)
                .Select(d => new AllDirectoratesViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return directorates_MI;
        }
    }
}
