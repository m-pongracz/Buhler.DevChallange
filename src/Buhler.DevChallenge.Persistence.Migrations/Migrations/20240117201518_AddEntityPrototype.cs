using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Buhler.DevChallenge.Persistence.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityPrototype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobileFoodFacilities",
                columns: table => new
                {
                    LocationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodItemsSearchOptimized = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileFoodFacilities", x => x.LocationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileFoodFacilities");
        }
    }
}
