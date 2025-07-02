using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moe.Core.Migrations
{
    /// <inheritdoc />
    public partial class updataFamliyEntiy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentAddressRegion",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "PreviousAddressRegion",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "WorkingMembersCount",
                table: "Families");

            migrationBuilder.RenameColumn(
                name: "WelfareProvider",
                table: "Families",
                newName: "Welfare");

            migrationBuilder.RenameColumn(
                name: "RetirementProvider",
                table: "Families",
                newName: "Retirement");

            migrationBuilder.RenameColumn(
                name: "PreviousNearestLandmark",
                table: "Families",
                newName: "PreviousAddress");

            migrationBuilder.RenameColumn(
                name: "FamilyProjectName",
                table: "Families",
                newName: "NearestLandmark");

            migrationBuilder.RenameColumn(
                name: "FamilyIncome",
                table: "Families",
                newName: "Totalincome");

            migrationBuilder.RenameColumn(
                name: "AssistanceProvider",
                table: "Families",
                newName: "FamilyProject");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectType",
                table: "Families",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PreviousRoomCount",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreviousHousingType",
                table: "Families",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreviousFullAddress",
                table: "Families",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentRoomCount",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentRentAmount",
                table: "Families",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentHousingType",
                table: "Families",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentFullAddress",
                table: "Families",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CanStartNewProject",
                table: "Families",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "CanDevelopProject",
                table: "Families",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddColumn<string>(
                name: "Assistance",
                table: "Families",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentAddress",
                table: "Families",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingCount",
                table: "Families",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingAmount",
                table: "Campaigns",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assistance",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "CurrentAddress",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "WorkingCount",
                table: "Families");

            migrationBuilder.DropColumn(
                name: "RemainingAmount",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "Welfare",
                table: "Families",
                newName: "WelfareProvider");

            migrationBuilder.RenameColumn(
                name: "Totalincome",
                table: "Families",
                newName: "FamilyIncome");

            migrationBuilder.RenameColumn(
                name: "Retirement",
                table: "Families",
                newName: "RetirementProvider");

            migrationBuilder.RenameColumn(
                name: "PreviousAddress",
                table: "Families",
                newName: "PreviousNearestLandmark");

            migrationBuilder.RenameColumn(
                name: "NearestLandmark",
                table: "Families",
                newName: "FamilyProjectName");

            migrationBuilder.RenameColumn(
                name: "FamilyProject",
                table: "Families",
                newName: "AssistanceProvider");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectType",
                table: "Families",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PreviousRoomCount",
                table: "Families",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PreviousHousingType",
                table: "Families",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PreviousFullAddress",
                table: "Families",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentRoomCount",
                table: "Families",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "CurrentRentAmount",
                table: "Families",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentHousingType",
                table: "Families",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentFullAddress",
                table: "Families",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CanStartNewProject",
                table: "Families",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CanDevelopProject",
                table: "Families",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentAddressRegion",
                table: "Families",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviousAddressRegion",
                table: "Families",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkingMembersCount",
                table: "Families",
                type: "integer",
                nullable: true);
        }
    }
}
