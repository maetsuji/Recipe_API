using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe_API.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDeleteForRecipesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientId1",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Recipes_IngredientId",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_IngredientId1",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "IngredientId1",
                table: "RecipeIngredient");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "RecipeIngredient",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientId",
                table: "RecipeIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipeId",
                table: "RecipeIngredient",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientId",
                table: "RecipeIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_Recipes_RecipeId",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_RecipeId",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "RecipeIngredient");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId1",
                table: "RecipeIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientId1",
                table: "RecipeIngredient",
                column: "IngredientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Ingredients_IngredientId1",
                table: "RecipeIngredient",
                column: "IngredientId1",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_Recipes_IngredientId",
                table: "RecipeIngredient",
                column: "IngredientId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
