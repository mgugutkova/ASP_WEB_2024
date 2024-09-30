using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GameZone.Data
{
    public class GameZoneDbContext : IdentityDbContext<IdentityUser>
    {
        public GameZoneDbContext(DbContextOptions<GameZoneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<GamerGame> GamerGame { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GamerGame>()
                .HasKey(ep => new { ep.GameId, ep.GamerId });

            builder.Entity<GamerGame>()
           .HasOne(ep => ep.Game)
           .WithMany(e => e.GamersGames)
           .OnDelete(DeleteBehavior.Restrict);



            builder
                .Entity<Genre>()
                .HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Adventure" },
                new Genre { Id = 3, Name = "Fighting" },
                new Genre { Id = 4, Name = "Sports" },
                new Genre { Id = 5, Name = "Racing" },
                new Genre { Id = 6, Name = "Strategy" });

            base.OnModelCreating(builder);
        }
    }
}
