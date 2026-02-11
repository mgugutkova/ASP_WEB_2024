using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Helpdesk.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<DirectoratesUnit> DirectoratesUnits { get; set; }

      //  public virtual DbSet<Operator> Operators { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<RequestState> RequestStates { get; set; }
        public virtual DbSet<RequestHistory> RequestsHistory { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<DirectoratesUnit>()
               .Property(a => a.IsActive)
               .HasDefaultValue(true);           

            builder.Entity<Request>()
            .Property(a => a.IsActive)
            .HasDefaultValue(true);

            builder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.RequestNumber)
                      .ValueGeneratedOnAdd(); // казва на EF, че се генерира от DB

                entity.HasIndex(e => e.RequestNumber)
                      .IsUnique(); // по желание, но силно препоръчително
            });

            base.OnModelCreating(builder);
        }
    }
}
