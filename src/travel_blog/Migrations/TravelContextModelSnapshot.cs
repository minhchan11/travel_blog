using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using travel_blog.Models;

namespace travel_blog.Migrations
{
    [DbContext(typeof(TravelContext))]
    partial class TravelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("travel_blog.Models.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("travel_blog.Models.NewPerson", b =>
                {
                    b.Property<int>("personId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("personId");

                    b.ToTable("NewPersons");
                });

            modelBuilder.Entity("travel_blog.Models.NewThing", b =>
                {
                    b.Property<int>("thingId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("thingId");

                    b.ToTable("NewThings");
                });

            modelBuilder.Entity("travel_blog.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.Property<int>("thingId");

                    b.HasKey("id");

                    b.HasIndex("thingId");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("travel_blog.Models.Thing", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Locationid");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.HasIndex("Locationid");

                    b.ToTable("things");
                });

            modelBuilder.Entity("travel_blog.Models.ThingPerson", b =>
                {
                    b.Property<int>("thingId");

                    b.Property<int>("personId");

                    b.HasKey("thingId", "personId");

                    b.HasIndex("personId");

                    b.HasIndex("thingId");

                    b.ToTable("ThingsPersons");
                });

            modelBuilder.Entity("travel_blog.Models.Person", b =>
                {
                    b.HasOne("travel_blog.Models.Thing", "Thing")
                        .WithMany("Persons")
                        .HasForeignKey("thingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("travel_blog.Models.Thing", b =>
                {
                    b.HasOne("travel_blog.Models.Location", "Location")
                        .WithMany("Things")
                        .HasForeignKey("Locationid");
                });

            modelBuilder.Entity("travel_blog.Models.ThingPerson", b =>
                {
                    b.HasOne("travel_blog.Models.NewPerson", "NewPerson")
                        .WithMany("ThingsPersons")
                        .HasForeignKey("personId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("travel_blog.Models.NewThing", "NewThing")
                        .WithMany("ThingsPersons")
                        .HasForeignKey("thingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
