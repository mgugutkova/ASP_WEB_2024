using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Directorates;
using Helpdesk.Infrastructure.Data.Model;
using Helpdesk.Infrastructure.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Services
{
    public class DirectoratesService : IDirectoratesService
    {
        private readonly IRepository repository;

        public DirectoratesService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddDirectoratesAsync(string name)
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
                    Name = d.Name,
                    IsActive = d.IsActive,
                })
                .OrderBy(x => x.Name)
                .ToListAsync();

            return directorates;
        }

        public Task EditDirectoratesAsync(int id, AllDirectoratesViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
