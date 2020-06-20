using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowersApp.Migrations
{
    public partial class AddFlowerUserPlants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlowerUserPlants",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPlants = table.Column<int>(nullable: false),
                    FlowerId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowerUserPlants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowerUserPlants_Flowers_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowerUserPlants_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowerUserPlants_FlowerId",
                table: "FlowerUserPlants",
                column: "FlowerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerUserPlants_UserId",
                table: "FlowerUserPlants",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowerUserPlants");
        }
    }
}
