using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Infrastructure.SeedDataDB
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            var seedData = new SeedData();

            builder.HasData(new Shop[]
            {
                seedData.BikeForShop
            });           
        }
    }
}
