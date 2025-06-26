using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class addcolmactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Families");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Families",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Families");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
