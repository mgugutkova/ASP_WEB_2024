using Fondacia.Core.Models.PersonnelUser;
using Fondacia.Core.Services;
using Microsoft.AspNetCore.Identity;

namespace Fondacia.Core.Interfaces
{
    public interface IPersonnel
    {
        Task<IdentityUser> CreateIdentityUserAsync(string email, string password);

        Task<ServiceResult<CreatePersonnelViewModel>> CreatePersonnelAsync(
    CreatePersonnelViewModel model, string currentUser, string identityUserId);

        Task<CompleteProfileViewModel> CompleteProfileAsync(CompleteProfileViewModel model, string userId);

        Task<bool> FindPersonnelAsync(string userId);

        Task<EditProfileViewModel> GetPersonnelAsync(string userId);

        Task<EditProfileViewModel> EditPersonnelAsync(EditProfileViewModel model, string currentUserId);

        Task<List<PersonnelListItemViewModel>> GetAllPersonnelAsync();

        Task<EditProfileViewModel?> GetPersonnelForEditAsync(Guid id);

    }
}
