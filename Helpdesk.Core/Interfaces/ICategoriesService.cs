using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.Directorates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Core.Interfaces
{
    public interface ICategoriesService
    {
        Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesAsync();
        Task<AllCategoriesViewModel?> FindCategoryAsync(int? id);
        Task AddCategoryAsync(string name);
        Task EditCategoryAsync(int id, AllCategoriesViewModel model);
    }
}
