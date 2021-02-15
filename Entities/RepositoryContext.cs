﻿
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
        public DbSet<Setlist> Setlists { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<SongPerformance> SongPerformances { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ExternalMediaObject> ExternalMediaObjects { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
