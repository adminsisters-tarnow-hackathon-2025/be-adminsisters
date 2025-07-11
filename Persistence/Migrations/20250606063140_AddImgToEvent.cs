﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_adminsisters.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImgToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "events",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "events");
        }
    }
}
