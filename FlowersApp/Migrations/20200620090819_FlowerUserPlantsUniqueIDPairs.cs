using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowersApp.Migrations
{
    public partial class FlowerUserPlantsUniqueIDPairs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlowerUserPlants_FlowerId",
                table: "FlowerUserPlants");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerUserPlants_FlowerId_UserId",
                table: "FlowerUserPlants",
                columns: new[] { "FlowerId", "UserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FlowerUserPlants_FlowerId_UserId",
                table: "FlowerUserPlants");

            migrationBuilder.CreateIndex(
                name: "IX_FlowerUserPlants_FlowerId",
                table: "FlowerUserPlants",
                column: "FlowerId");
        }
    }
}
