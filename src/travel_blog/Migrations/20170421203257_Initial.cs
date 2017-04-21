using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace travel_blog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NewPersons",
                columns: table => new
                {
                    personId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewPersons", x => x.personId);
                });

            migrationBuilder.CreateTable(
                name: "NewThings",
                columns: table => new
                {
                    thingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewThings", x => x.thingId);
                });

            migrationBuilder.CreateTable(
                name: "things",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Locationid = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_things", x => x.id);
                    table.ForeignKey(
                        name: "FK_things_locations_Locationid",
                        column: x => x.Locationid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThingsPersons",
                columns: table => new
                {
                    thingId = table.Column<int>(nullable: false),
                    personId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingsPersons", x => new { x.thingId, x.personId });
                    table.ForeignKey(
                        name: "FK_ThingsPersons_NewPersons_personId",
                        column: x => x.personId,
                        principalTable: "NewPersons",
                        principalColumn: "personId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThingsPersons_NewThings_thingId",
                        column: x => x.thingId,
                        principalTable: "NewThings",
                        principalColumn: "thingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    thingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_things_thingId",
                        column: x => x.thingId,
                        principalTable: "things",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_persons_thingId",
                table: "persons",
                column: "thingId");

            migrationBuilder.CreateIndex(
                name: "IX_things_Locationid",
                table: "things",
                column: "Locationid");

            migrationBuilder.CreateIndex(
                name: "IX_ThingsPersons_personId",
                table: "ThingsPersons",
                column: "personId");

            migrationBuilder.CreateIndex(
                name: "IX_ThingsPersons_thingId",
                table: "ThingsPersons",
                column: "thingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "ThingsPersons");

            migrationBuilder.DropTable(
                name: "things");

            migrationBuilder.DropTable(
                name: "NewPersons");

            migrationBuilder.DropTable(
                name: "NewThings");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
