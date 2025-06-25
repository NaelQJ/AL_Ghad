using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class addproptotablesponsoruseid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Sponsors",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_UserId",
                table: "Sponsors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Users_UserId",
                table: "Sponsors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Users_UserId",
                table: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_UserId",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sponsors");
        }
    }
}
