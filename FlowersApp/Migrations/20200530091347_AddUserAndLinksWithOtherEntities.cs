using Microsoft.EntityFrameworkCore.Migrations;

namespace FlowersApp.Migrations
{
    public partial class AddUserAndLinksWithOtherEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddedById",
                table: "Flowers",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AddedById",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flowers_AddedById",
                table: "Flowers",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AddedById",
                table: "Comments",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AddedById",
                table: "Comments",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flowers_Users_AddedById",
                table: "Flowers",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AddedById",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Flowers_Users_AddedById",
                table: "Flowers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Flowers_AddedById",
                table: "Flowers");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AddedById",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Flowers");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Comments");
        }
    }
}
