using Fondacia.Core.Interfaces;
using Fondacia.Core.Models.PersonnelUser;
using Fondacia.Infrastructure.Data;
using Fondacia.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fondacia.Core.Services
{
    public class PersonnelService : IPersonnel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
   //    private readonly ServiceResult<CreatePersonnelViewModel> _serviceResult;

        public PersonnelService(
            UserManager<IdentityUser> userManager,
            ApplicationDbContext context)
         //   ServiceResult<CreatePersonnelViewModel> serviceResult)
        {
            _userManager = userManager;
            _context = context;
          //  _serviceResult = serviceResult;
        }

        public async Task<CompleteProfileViewModel> CompleteProfileAsync(CompleteProfileViewModel model, string userId)
        {
            var personnel = new Personnel
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName,
                ShortName = model.ShortName,
                Notice = model.Notice,
                IsActive = true,

                IdentityUserId = userId,
                CreatedByUserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            _context.Personnel.Add(personnel);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<IdentityUser> CreateIdentityUserAsync(string email, string password)
        {
            var identityUser = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(identityUser, password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));                
            }
            return identityUser;
        }

        //   public async Task<CreatePersonnelViewModel> CreatePersonnelAsync(CreatePersonnelViewModel model, string currentUser, string identityUserId)

        public async Task<ServiceResult<CreatePersonnelViewModel>> CreatePersonnelAsync(
    CreatePersonnelViewModel model, string currentUser, string identityUserId)

        {
            var personnel = new Personnel
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName,
                ShortName = model.ShortName,
                Notice = model.Notice,
                IdentityUserId = identityUserId,
                CreatedByUserId = currentUser,
                CreatedOn = DateTime.UtcNow,
                IsActive = true
               
            };

            //  Качване на снимка в базата  // да се копира и в EditPersonnelAsync
            if (model.Photo != null)
            {
                // Ограничение: максимум 2 MB
                const int maxFileSize = 2 * 1024 * 1024;

                if (model.Photo.Length > maxFileSize)
                {
                    //throw new Exception("Снимката трябва да бъде до 2 MB.");
                    return ServiceResult<CreatePersonnelViewModel>.Fail("Снимката трябва да бъде до 2 MB.");

                }
                using var ms = new MemoryStream();
                await model.Photo.CopyToAsync(ms);

                personnel.ProfilePhoto = ms.ToArray();
                personnel.ProfilePhotoContentType = model.Photo.ContentType;
            }
            else
            {
                // Зареждаме default avatar
                var avatarPath = Path.Combine("wwwroot", "images", "avatar.png");
                personnel.ProfilePhoto = await System.IO.File.ReadAllBytesAsync(avatarPath);
                personnel.ProfilePhotoContentType = "image/png";
            }

            await _context.Personnel.AddAsync(personnel);
            await _context.SaveChangesAsync();
            
            return ServiceResult<CreatePersonnelViewModel>.Ok(model);
        }

        public async Task<bool> FindPersonnelAsync(string userId)
        {
            var exists = await _context.Personnel.AnyAsync(p => p.IdentityUserId == userId);

            if (!exists)
            {
                throw new Exception("Personnel not found for the given user ID.");
            }
            return exists;

        }

        public async Task<EditProfileViewModel> GetPersonnelAsync(string userId)
        {
            var personnel = await _context.Personnel
               .Include(p => p.IdentityUser)
               .FirstOrDefaultAsync(p => p.IdentityUserId == userId);

            if (personnel == null)
            {
                throw new Exception("Personnel not found for the given user ID.");
            }

            string? base64 = null;

            if (personnel.ProfilePhoto != null)
            {
                base64 = $"data:{personnel.ProfilePhotoContentType};base64,{Convert.ToBase64String(personnel.ProfilePhoto)}";
            }

            var model = new EditProfileViewModel
            {
                Id = personnel.Id,
                FullName = personnel.FullName,
                ShortName = personnel.ShortName,
                Notice = personnel.Notice,
                IsActive = personnel.IsActive,
                ExistingPhotoBase64 = base64               
            };

            return model;
        }

        public async Task<EditProfileViewModel> EditPersonnelAsync(EditProfileViewModel model, string currentUserId)
        {
            var personnel = await _context.Personnel
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (personnel == null)
            {
                throw new Exception("Personnel not found for the given ID.");
            }

            personnel.FullName = model.FullName;
            personnel.ShortName = model.ShortName;
            personnel.Notice = model.Notice;
            personnel.IsActive = model.IsActive;

            // Upload photo to database
            if (model.Photo != null)
            {
                using var ms = new MemoryStream();
                await model.Photo.CopyToAsync(ms);

                personnel.ProfilePhoto = ms.ToArray();
                personnel.ProfilePhotoContentType = model.Photo.ContentType;
            }

            personnel.ModifiedByUserId = currentUserId;
            personnel.ModifiedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return model;
        }

    }
}
