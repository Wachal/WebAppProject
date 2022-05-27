using ProjektApp.Rest.Database.Entities;
using Microsoft.EntityFrameworkCore;
// using ProjektApp.Database.Entities;



namespace ProjektApp.Rest.Database
{
    public class PeopleDb : DbContext
    {
        public PeopleDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PersonEntity> People {get; protected set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var perosnEntity = modelBuilder.Entity<PersonEntity>();
            perosnEntity.HasKey(pk=>pk.PersonId);
            perosnEntity.ToTable("Person");
            perosnEntity.Property(p=>p.FirstName).HasMaxLength(250);
        }


    }
}