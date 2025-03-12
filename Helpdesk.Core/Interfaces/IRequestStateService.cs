using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.RequestState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Interfaces
{
    public interface IRequestStateService
    {
        Task<IEnumerable<AllRequestStateViewModel>> AllRequestStateAsync();
        Task<AllRequestStateViewModel?> FindRequestStateAsync(int? id);
        Task AddRequestStateAsync(string name);
        Task EditRequestStateAsync(int id, AllRequestStateViewModel model);
    }
}
