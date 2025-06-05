using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_adminsisters.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedAchivement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "achievement",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false),
                    goal = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_achievement", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_achievement",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    achievement_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_achievement", x => new { x.user_id, x.achievement_id });
                    table.ForeignKey(
                        name: "fk_user_achievement_achievement_achievement_id",
                        column: x => x.achievement_id,
                        principalTable: "achievement",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_achievement_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_achievement_achievement_id",
                table: "user_achievement",
                column: "achievement_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_achievement");

            migrationBuilder.DropTable(
                name: "achievement");
        }
    }
}
