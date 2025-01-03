using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Infrastructure.SeedDataDB
{
    internal class InterestConfiguration : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
        {
            var seedData = new SeedData();

            builder.HasData(new Interest[]
            {
                seedData.TVInterest
            });
           
        }
    }
}
