using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.Request;
using Helpdesk.Core.Models.RequestState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
