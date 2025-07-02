using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class addDeviceForFamliyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Families_FamilyId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_FamilyId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DevicePath",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Devices",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FamilyDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceImge = table.Column<string>(type: "text", nullable: true),
                    DisplayId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyDevices_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDevices_DeviceId",
                table: "FamilyDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDevices_FamilyId",
                table: "FamilyDevices",
                column: "FamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDevices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Devices");

            migrationBuilder.AddColumn<string>(
                name: "DevicePath",
                table: "Devices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Devices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Devices_FamilyId",
                table: "Devices",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Families_FamilyId",
                table: "Devices",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
