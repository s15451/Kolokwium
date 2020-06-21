using Kolokwium.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class ArtistsDbContext : DbContext
    {
        public DbSet<Artist> Artists{ get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<ArtistEvent> ArtistsEvents { get; set; }

        public DbSet<Organiser> Organisers { get; set; }

        public DbSet<EventOrganiser> EventOrganisers { get; set; }

        public ArtistsDbContext() { }

        public ArtistsDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArtistEFConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistEventEFConfiguration());
            modelBuilder.ApplyConfiguration(new EventEFConfiguration());
            modelBuilder.ApplyConfiguration(new EventOrganiserEFConfiguration());
            modelBuilder.ApplyConfiguration(new OrganiserEFConfiguration());
        }
    }
}
