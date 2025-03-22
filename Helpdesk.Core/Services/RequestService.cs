using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.Request;
using Helpdesk.Infrastructure.Data.Model;
using Helpdesk.Infrastructure.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Helpdesk.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository repository;
        //private readonly UserManager<ApplicationUser> userManager;
        //private readonly IUserService userService;
        //private readonly IUserStore<ApplicationUser> userStore;
        private readonly IHttpContextAccessor httpContextAccessor;


        public RequestService(IRepository _repository,
            //UserManager<ApplicationUser> _userManager,
            //IUserService _userService,
            //IUserStore<ApplicationUser> _userStore,
            IHttpContextAccessor _httpContextAccessor
)
        {
            repository = _repository;
            //userManager = _userManager;
            //userService = _userService;
            //userStore = _userStore;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task AddRequestAsync(string description, int categoryId)
        {
            var currentUserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;


            var request = new Request
            {
                Id = new Guid(),
                Description = description,
                UserId = currentUserId,
                CategoryId = categoryId,
                StartDate = DateTime.UtcNow,
                RequestStateId = 1,
            };

            await repository.AddAsync(request);
            await repository.SaveChangesAsync();
        }

        public Task<IEnumerable<RequestViewModel>> AllRequestAsync()
        {
            throw new NotImplementedException();
        }

        public Task EditRequestAsync(Guid id, RequestViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<RequestViewModel?> FindRequestAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RequestViewModel>> MyRequestAsync(string userId)
        {
            var requests = await repository.All<Request>()
                .Where(x => x.UserId == userId)
                .Where(x => x.IsActive == true)
                .Select(r => new RequestViewModel()
                {
                    Description = r.Description,
                })
                .ToListAsync();

            return requests;
        }

        public async Task<IEnumerable<AllCategoriesViewModel>> AllCategoryList()
        {

            var categories =  await repository.AllReadOnly<Category>()
                         .Select(d => new AllCategoriesViewModel()
                         {
                             Id = d.Id,
                             Name = d.Name,
                         })
                         .OrderBy(x => x.Name)
                         .ToListAsync();

            return categories;
        }
    }
}
