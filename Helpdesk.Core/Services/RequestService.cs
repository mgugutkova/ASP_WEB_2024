using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.ApplicationUser;
using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.Request;
using Helpdesk.Infrastructure.Data.Model;
using Helpdesk.Infrastructure.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Helpdesk.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        //private readonly IUserService userService;
        //private readonly IUserStore<ApplicationUser> userStore;
        private readonly IHttpContextAccessor httpContextAccessor;


        public RequestService(IRepository _repository,
            UserManager<ApplicationUser> _userManager,
            //IUserService _userService,
            //IUserStore<ApplicationUser> _userStore,
            IHttpContextAccessor _httpContextAccessor
)
        {
            repository = _repository;
            userManager = _userManager;
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

        public async Task<IEnumerable<RequestViewModel>> AllRequestAsync()
        {
            var requests = await repository.All<Request>()            
               .Where(x => x.IsActive == true)
               .Select(r => new RequestViewModel()
               {
                   Id = r.Id,
                   Description = r.Description,
                   UserId = r.UserId,
                   Address = r.UserMI.Address,
                   Phone = r.UserMI.PhoneNumber ?? string.Empty,
                   DirectorateName = r.UserMI.DirectoratesUnit.Name,
                   CategoryId = r.CategoryId,
                   StartDate = r.StartDate,
                   EndDate = r.EndDate,
                   RequestStateId = r.RequestStateId,
                   RequestState = r.RequestState.Name,
                   OperatorId = r.OperatorId,
                   OperatorName = r.Operator.UserId ?? string.Empty,
                   Comment = r.Comment,
                   IsActive = r.IsActive,
                   CategoryName = r.Category.Name,
                   UserFullName = r.UserMI.FirstName + " " + r.UserMI.LastName,          

               })
               .ToListAsync();

            return requests;
        }

        public async Task EditRequestAsync(Guid id, RequestViewModel model)
        {
            var request = await repository.GetByIdAsync<Request>(id);

            if (request != null)
            {
                request.Description = model.Description;
                request.CategoryId = model.CategoryId;
                request.StartDate = model.StartDate;                
                request.RequestStateId = model.RequestStateId;            
                request.OperatorId = model.OperatorId;
                request.Comment = model.Comment;
                request.IsActive = model.IsActive;

                if (model.RequestStateId == 3)
                {
                    request.EndDate = DateTime.UtcNow;
                }

                await repository.SaveChangesAsync();
            }
        }

        public async Task<RequestViewModel?> FindRequestAsync(Guid? id)
        {
            var request = await repository.All<Request>()
                .Where(x => x.Id == id)
                .Where(x => x.IsActive == true)
                .Select(r => new RequestViewModel()
                {
                    Id = r.Id,
                    Description = r.Description,
                    UserId = r.UserId,
                    CategoryId = r.CategoryId,
                    CategoryName = r.Category.Name,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    RequestStateId = r.RequestStateId,
                    RequestState = r.RequestState.Name,
                    OperatorId = r.OperatorId,
                    OperatorName = r.Operator.UserId ?? string.Empty,
                    Comment = r.Comment,
                    IsActive = r.IsActive,
                })
                .FirstOrDefaultAsync();

            return request;
        }

        public async Task<IEnumerable<RequestViewModel>> MyRequestAsync(string userId)
        {

            var requests = await repository.All<Request>()
                 .Where(x => x.UserId == userId)
                 .Where(x => x.IsActive == true)
                 .Select(r => new RequestViewModel()
                 {
                     Id = r.Id,
                     Description = r.Description,
                     CategoryId = r.CategoryId,
                     CategoryName = r.Category.Name,
                     StartDate = r.StartDate,
                     EndDate = r.EndDate,
                     RequestState = r.RequestState.Name,
                     OperatorName = r.Operator.UserId ?? string.Empty
                     // UserFullName = fullName ?? string.Empty
                 })
                 .OrderByDescending(x => x.StartDate)
                 .ToListAsync();

            return requests;
        }

        public async Task<IEnumerable<AllCategoriesViewModel>> AllCategoryList()
        {

            var categories = await repository.AllReadOnly<Category>()
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
