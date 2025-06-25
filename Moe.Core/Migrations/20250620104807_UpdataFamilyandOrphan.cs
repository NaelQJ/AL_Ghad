using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdataFamilyandOrphan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Families_FamilyId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Orphans_OrphanId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Families_FamilyId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orphans_Families_FamilyId",
                table: "Orphans");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "Orphans",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Families_FamilyId",
                table: "Attachments",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Orphans_OrphanId",
                table: "Attachments",
                column: "OrphanId",
                principalTable: "Orphans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Families_FamilyId",
                table: "Devices",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Orphans_Families_FamilyId",
                table: "Orphans",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Families_FamilyId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Orphans_OrphanId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Families_FamilyId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orphans_Families_FamilyId",
                table: "Orphans");

            migrationBuilder.AlterColumn<Guid>(
                name: "FamilyId",
                table: "Orphans",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Families_FamilyId",
                table: "Attachments",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Orphans_OrphanId",
                table: "Attachments",
                column: "OrphanId",
                principalTable: "Orphans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Families_FamilyId",
                table: "Devices",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orphans_Families_FamilyId",
                table: "Orphans",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
