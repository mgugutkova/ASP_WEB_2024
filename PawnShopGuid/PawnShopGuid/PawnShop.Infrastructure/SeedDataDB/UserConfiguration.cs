using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawnShop.Infrastructure.Data.Model;


namespace PawnShop.Infrastructure.SeedDataDB
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var seedData = new SeedData();

            builder.HasData(new ApplicationUser[]
            {
                seedData.UserKsef,
                seedData.UserMsef,
                seedData.AdminUser,
                seedData.GuestUser
            });
        }
    }


}
