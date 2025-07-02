using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class UdpateWarehouseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Sponsors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndSpons",
                table: "Sponsors",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Wallet",
                table: "Sponsors",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Orphans",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Families",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FamilyId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrphanId = table.Column<Guid>(type: "uuid", nullable: true),
                    DonorName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    Email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    DonationType = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    DonationAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DonationImage = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    DonationStatus = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Donationlocation = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ReceivedName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    MovId = table.Column<Guid>(type: "uuid", nullable: true),
                    DisplayId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Warehouses_Orphans_OrphanId",
                        column: x => x.OrphanId,
                        principalTable: "Orphans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_FamilyId",
                table: "Warehouses",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_OrphanId",
                table: "Warehouses",
                column: "OrphanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropColumn(
                name: "EndSpons",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Sponsors");

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Sponsors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Orphans",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Score",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
