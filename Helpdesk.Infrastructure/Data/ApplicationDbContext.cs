using Helpdesk.Infrastructure.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public virtual DbSet<Operator> Operators { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<RequestState> RequestStates { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<DirectoratesUnit>()
               .Property(a => a.IsActive)
               .HasDefaultValue(true);

            builder.Entity<Operator>()
             .Property(a => a.IsActive)
             .HasDefaultValue(true);

            builder.Entity<Request>()
            .Property(a => a.IsActive)
            .HasDefaultValue(true);

            base.OnModelCreating(builder);
        }
    }
}
