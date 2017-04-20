using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace travel_blog.Models
{
    public class TravelContext : DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Thing> Things { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<NewThing> NewThings { get; set; }
        public virtual DbSet<NewPerson> NewPersons { get; set; }
        public DbSet<ThingPerson> ThingsPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Travel;integrated security=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThingPerson>()
                .HasKey(t => new { t.thingId, t.personId });

            modelBuilder.Entity<ThingPerson>()
                .HasOne(pt => pt.NewThing)
                .WithMany(p => p.ThingsPersons)
                .HasForeignKey(pt => pt.thingId);

            modelBuilder.Entity<ThingPerson>()
               .HasOne(pt => pt.NewPerson)
               .WithMany(p => p.ThingsPersons)
               .HasForeignKey(pt => pt.personId);
        }
    }
}
