using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class addcolminfamliyandorphanIssponsored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orphans");

            migrationBuilder.AddColumn<bool>(
                name: "IsSponsored",
                table: "Orphans",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSponsored",
                table: "Families",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSponsored",
                table: "Orphans");

            migrationBuilder.DropColumn(
                name: "IsSponsored",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Families");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orphans",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
