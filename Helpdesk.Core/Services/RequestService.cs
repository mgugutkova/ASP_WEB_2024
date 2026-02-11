using Helpdesk.Core.Interfaces;
using Helpdesk.Core.Models.ApplicationUser;
using Helpdesk.Core.Models.Categoris;
using Helpdesk.Core.Models.Request;
using Helpdesk.Core.Models.RequestHistory;
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

        public async Task AddRequestAsync(string description, int categoryId, IFormFile? attachment)
        {
            var currentUserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            var bulgariaTime = DateTime.UtcNow;
            // Get the Bulgaria time zone
            TimeZoneInfo bulgariaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
            // Convert UTC time to Bulgaria time
            DateTime startDate = TimeZoneInfo.ConvertTimeFromUtc(bulgariaTime, bulgariaTimeZone);

            var request = new Request
            {
                Id = new Guid(),
                Description = description,
                UserId = currentUserId,
                CategoryId = categoryId,
                StartDate = startDate,
                RequestStateId = 1
            };

            byte[] fileData = Array.Empty<byte>();

            if (attachment != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await attachment.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                }
                request.Data = fileData;
                request.FileName = attachment.FileName;
                request.ContentType = attachment.ContentType;
            }

            await repository.AddAsync(request);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<RequestViewModel>> AllRequestAsync()
        {
            var requests = await repository.All<Request>()
               .AsNoTracking()
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
                   OperatorName = r.Operator.FirstName + " " + r.Operator.LastName,
                   ManagerName = r.Manager.FirstName + " " + r.Manager.LastName,
                   Comment = r.Comment,
                   IsActive = r.IsActive,
                   CategoryName = r.Category.Name,
                   UserFullName = r.UserMI.FirstName + " " + r.UserMI.LastName,
                   RequestNumber = r.RequestNumber
               })
               .OrderByDescending(x => x.StartDate)
               .ToListAsync();

            return requests;
        }


        public async Task EditRequestAsync(Guid id, RequestViewModel model)
        {
            var currentUserId = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            var request = await repository.GetByIdAsync<Request>(id);


            var bulgariaTime = DateTime.UtcNow;
            TimeZoneInfo bulgariaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");

            if (request != null)
            {
                var oldRequestStateId = request.RequestStateId;

                if (model.RequestStateId != request.RequestStateId)
                {
                    await AddHistoryRecord(currentUserId, bulgariaTime, model);
                }

                //if (model.RequestStateId == 1 && model.OperatorId != null)
                //{
                //    model.OperatorId = null;
                //}

                request.Description = model.Description;
                request.RequestStateId = model.RequestStateId;
                request.OperatorId = model.OperatorId;
                request.Comment = model.Comment;

                if (model.RequestStateId == 3)
                {
                    DateTime endDate = TimeZoneInfo.ConvertTimeFromUtc(bulgariaTime, bulgariaTimeZone);
                    request.EndDate = endDate;
                    request.ManagerId = currentUserId;
                }

                if (model.RequestStateId == 1 && model.OperatorId != null)
                {
                    request.RequestStateId = 2;
                    model.RequestStateId = 2;
                    await AddHistoryRecord(currentUserId, bulgariaTime, model);
                }

                await repository.SaveChangesAsync();
            }
        }


        public async Task AddHistoryRecord(string currentUserId,
            DateTime bulgariaTime,
            RequestViewModel model)
        {
            TimeZoneInfo bulgariaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("FLE Standard Time");
            DateTime changedDate = TimeZoneInfo.ConvertTimeFromUtc(bulgariaTime, bulgariaTimeZone);

            var history = new RequestHistory
            {
                RequestId = model.Id,
                RequestStateId = model.RequestStateId,
                ChangeDate = changedDate,
                ChangedById = currentUserId,
            };

            await repository.AddAsync(history);
            await repository.SaveChangesAsync();
        }

        public async Task<RequestViewModel?> FindRequestAsync(Guid? id)
        {
            var request = await repository.All<Request>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Where(x => x.IsActive == true)
                .Select(r => new RequestViewModel()
                {
                    Id = r.Id,
                    Description = r.Description,
                    UserId = r.UserId,
                    Address = r.UserMI.Address,
                    Phone = r.UserMI.PhoneNumber,
                    UserFullName = r.UserMI.FirstName + " " + r.UserMI.LastName,
                    CategoryId = r.CategoryId,
                    CategoryName = r.Category.Name,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    RequestStateId = r.RequestStateId,
                    RequestState = r.RequestState.Name,
                    OperatorId = r.OperatorId,
                    OperatorName = r.Operator.FirstName + " " + r.Operator.LastName,
                    ManagerName = r.Manager.FirstName + " " + r.Manager.LastName,
                    Comment = r.Comment,
                    Satisfaction = r.Satisfaction,
                    IsActive = r.IsActive,
                    Attachment = r.Data != null ? new FormFile(new MemoryStream(r.Data), 0, r.Data.Length, "file", "attachment") : null,
                    FileName = r.FileName,
                    RequestNumber = r.RequestNumber
                })
                .FirstOrDefaultAsync();

            request.AdminList = await AllOperatorsAsync();

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
                     OperatorName = r.Operator.FirstName + " " + r.Operator.LastName,
                     Comment = r.Comment,
                     Attachment = r.Data != null ? new FormFile(new MemoryStream(r.Data), 0, r.Data.Length, "file", "attachment") : null,
                     RequestNumber = r.RequestNumber
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
        public async Task<IEnumerable<ITAdminViewModel>> AllManagerssAsync()
        {
            var managers = await userManager.GetUsersInRoleAsync("Admin");

            var model = managers
                .Select(x => new ITAdminViewModel()
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    RoleName = x.RoleName,
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            return model;
        }

        public async Task<IEnumerable<ITAdminViewModel>> AllOperatorsAsync()
        {
            //var users =  userManager.Users
            //   .Where(x => x.RoleName == RoleNameItems.Operator.ToString());
            var operators = await userManager.GetUsersInRoleAsync("Operator");
            var admins = await userManager.GetUsersInRoleAsync("Admin");

            var model = operators.Concat(admins)
                .Where(x => x.IsActive == true)
                .Select(x => new ITAdminViewModel()
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    RoleName = x.RoleName,
                })
                .OrderBy(x => x.FirstName)
                .Distinct()
                .ToList();


            return model;
        }

        public async Task<IEnumerable<RequestHistoryViewModel?>> AllRequestHistoryAsync(Guid? Id)
        {
            var history = await repository.All<RequestHistory>()
               .Where(x => x.RequestId == Id)
               .Select(r => new RequestHistoryViewModel()
               {
                   RequestStateId = r.RequestStateId,
                   RequestState = r.RequestState.Name,
                   ChangeDate = r.ChangeDate,
                   ChangedById = r.ChangedById,
                   ChangedByUser = r.ChangedByUser.FirstName + " " + r.ChangedByUser.LastName,
                   RequestId = r.RequestId,
                   id = r.id,
                   RequestNumber = r.Request.RequestNumber
               })
                .OrderByDescending(x => x.ChangeDate)
                .ToListAsync();

            if (history == null)
            {
                return new List<RequestHistoryViewModel>();
            }
            else
            {
                return history;
            }
        }
    }
}
