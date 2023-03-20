using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeLogAppv1.Data.Migrations
{
    public partial class initialbuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrewTime = table.Column<double>(type: "float", nullable: false),
                    DoseGrams = table.Column<double>(type: "float", nullable: false),
                    GrindSetting = table.Column<int>(type: "int", nullable: false),
                    WaterTemp = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brew", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brew");
        }
    }
}
