using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_adminsisters.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAchievements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_achievement_achievement_achievement_id",
                table: "user_achievement");

            migrationBuilder.DropPrimaryKey(
                name: "pk_achievement",
                table: "achievement");

            migrationBuilder.RenameTable(
                name: "achievement",
                newName: "achievements");

            migrationBuilder.AddPrimaryKey(
                name: "pk_achievements",
                table: "achievements",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_achievement_achievements_achievement_id",
                table: "user_achievement",
                column: "achievement_id",
                principalTable: "achievements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_achievement_achievements_achievement_id",
                table: "user_achievement");

            migrationBuilder.DropPrimaryKey(
                name: "pk_achievements",
                table: "achievements");

            migrationBuilder.RenameTable(
                name: "achievements",
                newName: "achievement");

            migrationBuilder.AddPrimaryKey(
                name: "pk_achievement",
                table: "achievement",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_achievement_achievement_achievement_id",
                table: "user_achievement",
                column: "achievement_id",
                principalTable: "achievement",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
