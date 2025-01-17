using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Infrastructure.SeedDataDB
{
    internal class AgreementConfiguration : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            var seedData = new SeedData();

            builder.HasData(new Agreement[]
            {
                seedData.TV,
                seedData.Laptop,
                seedData.Bike
            });
        }
    }
}
