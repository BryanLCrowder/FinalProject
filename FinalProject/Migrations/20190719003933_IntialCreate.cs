using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exotic",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<decimal>(nullable: false),
                    SubModel = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Vin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exotic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Muscle",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Manufacture = table.Column<string>(nullable: true),
                    Model = table.Column<decimal>(nullable: false),
                    SubModel = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muscle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tuner",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SubModel = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Vin = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuner", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exotic");

            migrationBuilder.DropTable(
                name: "Muscle");

            migrationBuilder.DropTable(
                name: "Tuner");
        }
    }
}
