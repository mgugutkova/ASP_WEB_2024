using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawnShop.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnShop.Infrastructure.SeedDataDB
{
    internal class AgreementStateConfiguration : IEntityTypeConfiguration<AgreementState>
    {
        public void Configure(EntityTypeBuilder<AgreementState> builder)
        {
            var seedData = new SeedData();

            builder.HasData(new AgreementState[]
            {
                seedData.AwaitingApproval,
                seedData.Approved,
                seedData.Finished,
                seedData.Late,
                seedData.ForShop
            });
        }
    }
}
