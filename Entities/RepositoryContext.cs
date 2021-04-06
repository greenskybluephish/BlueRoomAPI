
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Venue> Venues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Song>()
                .HasMany(o => o.SongPerformances)
                .WithOne(l => l.Song)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Setlist>()
                .HasMany(o => o.SongPerformances)
                .WithOne(l => l.Setlist)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
