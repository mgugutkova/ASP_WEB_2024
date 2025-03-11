using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Categoris;
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
    public class CategoriesService : ICategoriesService
    {

        private readonly IRepository repository;

        public CategoriesService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task AddCategoryAsync(string name)
        {
            var category = new Category
            {
                Name = name
            };
             
            await repository.AddAsync(category);
            await repository.SaveChangesAsync();
                
        }

        public async Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesAsync()
        {
           var categories = await repository.All<Category>()
                .Select(c => new AllCategoriesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .OrderBy(c => c.Name)
                .ToListAsync();

            return categories;
        }

        public async Task EditCategoryAsync(int id, AllCategoriesViewModel model)
        {
            var category = await repository.GetByIdAsync<Category>(id);

            if (category != null)
            {
                category.Name = model.Name; 
                await repository.SaveChangesAsync();
            }
        }

        public async Task<AllCategoriesViewModel?> FindCategoryAsync(int? id)
        {
            var category = await repository.All<Category>()
                .Where(c => c.Id == id)
                .Select( x => new AllCategoriesViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync();

            return category;
        }
    }

}
