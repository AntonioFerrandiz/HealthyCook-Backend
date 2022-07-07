using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthyCook_Backend.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RestaurantID",
                table: "Recipes",
                column: "RestaurantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Restaurants_RestaurantID",
                table: "Recipes",
                column: "RestaurantID",
                principalTable: "Restaurants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Restaurants_RestaurantID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RestaurantID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Recipes");
        }
    }
}
