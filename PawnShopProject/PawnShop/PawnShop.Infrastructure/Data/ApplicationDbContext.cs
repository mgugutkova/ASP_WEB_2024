using Microsoft.AspNetCore.Identity;
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

        private ApplicationUser AdminUser { get; set; }
        private ApplicationUser UserMsef { get; set; }
        private ApplicationUser UserKsef { get; set; }
        private ApplicationUser GuestUser { get; set; }
        private Client ClientMsef {  get; set; }
        private Client ClientKsef {  get; set; }

		public DbSet<Agreement> Agreements { get; set; }

		public DbSet<Client> Clients { get; set; }

		public DbSet<AgreementState> AgreementStates { get; set; }

		public DbSet<Interest> Interests { get; set; }	

		public DbSet<Shop> Shop { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsers();
            builder.Entity<ApplicationUser>()
                .HasData(AdminUser, UserMsef, UserKsef, GuestUser);

            SeedClient();
            builder.Entity<Client>()
                .HasData(ClientMsef, ClientKsef);

            base.OnModelCreating(builder);

            builder
                .Entity<AgreementState>()
                .HasData(
                    new AgreementState { Id = 1, Name = "Аwaiting approval" },
                    new AgreementState { Id = 2, Name = "Approved (Active)" },
                    new AgreementState { Id = 3, Name = "Finished" },
                    new AgreementState { Id = 4, Name = "Late" },
                    new AgreementState { Id = 5, Name = "For а Shop" }
                    );


        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "b97f29e7-1edd-4666-a8d8-8882858d7ccf",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@abv.bg",
                NormalizedEmail = "ADMIN@ABV.BG",
                FirstName = "Boss",
                LastName = "Petrov"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "123456");

            UserMsef = new ApplicationUser()
            {
                Id = "5cf194c7-b26e-42ed-8efd-d98c7980373b",
                UserName = "msef",
                NormalizedUserName = "MSEF",
                Email = "msef@abv.bg",
                NormalizedEmail = "MSEF@ABV.BG",
                FirstName = "Mary",
                LastName = "Seferov"
            };

            UserMsef.PasswordHash = hasher.HashPassword(UserMsef, "123456");

            UserKsef = new ApplicationUser()
            {
                Id = "ffae7662-4ff3-4698-8f36-c4e4f392da18",
                UserName = "ksef",
                NormalizedUserName = "KSEF",
                Email = "ksef@abv.bg",
                NormalizedEmail = "KSEF@ABV.BG",
                FirstName = "Kalin",
                LastName = "Sarafov"
            };

            UserKsef.PasswordHash = hasher.HashPassword(UserKsef, "123456");


            GuestUser = new ApplicationUser()
            {
                Id = "70e39283-bd42-4d0a-aa2e-46d2a31c4f87",
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@abv.bg",
                NormalizedEmail = "GUEST@ABV.BG",
                FirstName = "Galin",
                LastName = "Gogov"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "123456");
        }

        private void SeedClient()
        {
            ClientMsef = new Client
            {
                Id = 1,
                PhoneNumber = "1234567890",
                Address = "Sofiq,Dianabad",
                UserId = UserMsef.Id,
                IsDeleted = false
            };

            ClientKsef = new Client
            {
                Id = 2,
                PhoneNumber = "1234599999",
                Address = "Plovdiv,Izgrev",
                UserId = UserKsef.Id,
                IsDeleted = false
            };
        }
    }
}
