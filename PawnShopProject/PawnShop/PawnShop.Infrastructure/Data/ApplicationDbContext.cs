using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawnShop.Infrastructure.Data.Model;

namespace PawnShop.Infrastructure.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Contract> Contracts { get; set; }

		public DbSet<Client> Clients { get; set; }

		public DbSet<ContractState> ContractStates { get; set; }

		public DbSet<Interest> Interests { get; set; }	

		public DbSet<Shop> Shop { get; set; }

		public DbSet<Period> Periods { get; set; }

    }
}
