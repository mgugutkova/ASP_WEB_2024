using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Infrastructure.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Agreement> Agreements { get; set; }

		public DbSet<Client> Clients { get; set; }

		public DbSet<AgreementState> AgreementStates { get; set; }

		public DbSet<Interest> Interests { get; set; }	

		public DbSet<Shop> Shop { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<AgreementState>()
                .HasData(
                    new AgreementState { Id = 1, Name = "Аwaiting approval" },
                    new AgreementState { Id = 2, Name = "Approved (Active)" },
                    new AgreementState { Id = 3, Name = "Finish" },
                    new AgreementState { Id = 4, Name = "Late" });
                   
        }
    }
}
