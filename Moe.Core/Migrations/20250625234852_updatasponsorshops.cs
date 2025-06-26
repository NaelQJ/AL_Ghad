using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class updatasponsorshops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SponsorShips_Families_FamilyId",
                table: "SponsorShips");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorShips_Orphans_OrphanId",
                table: "SponsorShips");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorShips_Sponsors_SponsorId",
                table: "SponsorShips");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorShips_Families_FamilyId",
                table: "SponsorShips",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorShips_Orphans_OrphanId",
                table: "SponsorShips",
                column: "OrphanId",
                principalTable: "Orphans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorShips_Sponsors_SponsorId",
                table: "SponsorShips",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SponsorShips_Families_FamilyId",
                table: "SponsorShips");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorShips_Orphans_OrphanId",
                table: "SponsorShips");

            migrationBuilder.DropForeignKey(
                name: "FK_SponsorShips_Sponsors_SponsorId",
                table: "SponsorShips");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorShips_Families_FamilyId",
                table: "SponsorShips",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorShips_Orphans_OrphanId",
                table: "SponsorShips",
                column: "OrphanId",
                principalTable: "Orphans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SponsorShips_Sponsors_SponsorId",
                table: "SponsorShips",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
