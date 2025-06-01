using Helpdesk.Core.Models.ApplicationUser;
using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.Request;
using Helpdesk.Core.Models.RequestHistory;

namespace Helpdesk.Core.Interfaces
{
    public interface IRequestService
    {
        Task<IEnumerable<RequestViewModel>> AllRequestAsync();
        Task<IEnumerable<RequestViewModel>> MyRequestAsync(string userId);
        Task<RequestViewModel?> FindRequestAsync(Guid? id);
        Task AddRequestAsync(string description, int categoryId);
        Task EditRequestAsync(Guid id, RequestViewModel model);
        Task<IEnumerable<AllCategoriesViewModel>> AllCategoryList();
        Task<IEnumerable<ITAdminViewModel>> AllOperatorsAsync();
        Task<IEnumerable<ITAdminViewModel>> AllManagerssAsync();
        Task<IEnumerable<RequestHistoryViewModel?>> AllRequestHistoryAsync(Guid? Id);

    }
}
