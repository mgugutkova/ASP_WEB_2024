using Helpdesk.Core.Models.RequestState;

namespace Helpdesk.Core.Interfaces
{
    public interface IRequestStateService
    {
        Task<IEnumerable<RequestServiceViewModel>> AllRequestStateAsync();
        Task<RequestServiceViewModel?> FindRequestStateAsync(int? id);
        Task AddRequestStateAsync(string name);
        Task EditRequestStateAsync(int id, RequestServiceViewModel model);
    }
}
