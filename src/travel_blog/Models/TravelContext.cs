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
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Travel;integrated security=True");
        }
    }
}
