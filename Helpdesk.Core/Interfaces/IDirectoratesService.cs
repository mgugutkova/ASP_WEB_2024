using Helpdesk.Core.Models.Directorates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Interfaces
{
    public interface IDirectoratesService
    {
        Task<IEnumerable<AllDirectoratesViewModel>> AllDirectoratesAsync();
        Task<AllDirectoratesViewModel?> FindDirectorateAsync(int? id);
        Task AddDirectorateAsync(string name);
        Task EditDirectorateAsync(int id, AllDirectoratesViewModel model);

        Task<IEnumerable<AllDirectoratesViewModel>> GetDirectoratesActive();

    }
}
