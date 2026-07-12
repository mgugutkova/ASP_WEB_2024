using Fondacia.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fondacia.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clients> Clients { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Ateliers> Ateliers { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<VacationClients> VacationClients { get; set; }
        public DbSet<VacationPersonnel> VacationPersonnel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Personnel>()
               .Property(a => a.IsActive)
               .HasDefaultValue(true);

            builder.Entity<Clients>()
                .Property(a => a.IsActive)
                .HasDefaultValue(true);

            builder.Entity<Personnel>()
                .HasOne(p => p.IdentityUser)
                .WithMany()
                .HasForeignKey(p => p.IdentityUserId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }
    }
}
