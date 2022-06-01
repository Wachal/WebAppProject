using ProjektApp.Rest.Database.Entities;
using Microsoft.EntityFrameworkCore;
// using ProjektApp.Database.Entities;

namespace ProjektApp.Rest.Database
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PersonEntity> People {get; protected set;}

        public DbSet<CardEntity> CardEntries {get; protected set;}

        public DbSet<CardTimesEntity> CardTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var perosnEntity = modelBuilder.Entity<PersonEntity>();
            perosnEntity.HasKey(pk=>pk.PersonId);
            perosnEntity.ToTable("Person");

            var CardEntity = modelBuilder.Entity<CardEntity>();
            CardEntity.HasKey(pk=>pk.CardEntryId);
            CardEntity.ToTable("CardEntries");

            var CardTimes = modelBuilder.Entity<CardTimesEntity>();
            CardTimes.HasNoKey();

        }
    }
}