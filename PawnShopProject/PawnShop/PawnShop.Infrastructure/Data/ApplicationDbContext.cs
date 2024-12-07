using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawnShop.Infrastructure.Data.Model;
using PawnShop.Infrastructure.SeedDataDB;

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
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new ClientConfiguration());
			builder.ApplyConfiguration(new AgreementStateConfiguration());
			builder.ApplyConfiguration(new AgreementConfiguration());

			base.OnModelCreating(builder);
           
        }
    }
}
