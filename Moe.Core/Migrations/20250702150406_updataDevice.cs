using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class updataDevice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDevices_Devices_DeviceId",
                table: "FamilyDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDevices_Families_FamilyId",
                table: "FamilyDevices");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDevices_Devices_DeviceId",
                table: "FamilyDevices",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDevices_Families_FamilyId",
                table: "FamilyDevices",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDevices_Devices_DeviceId",
                table: "FamilyDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDevices_Families_FamilyId",
                table: "FamilyDevices");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDevices_Devices_DeviceId",
                table: "FamilyDevices",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDevices_Families_FamilyId",
                table: "FamilyDevices",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
