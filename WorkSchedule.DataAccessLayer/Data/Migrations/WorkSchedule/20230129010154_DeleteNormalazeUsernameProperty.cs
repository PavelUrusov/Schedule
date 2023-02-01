#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class DeleteNormalazeUsernameProperty : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            "IX_Users_NormalizedUsername",
            "Users");

        migrationBuilder.DropColumn(
            "NormalizedUsername",
            "Users");

        migrationBuilder.AlterColumn<string>(
            "Password",
            "Users",
            "character varying(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(64)",
            oldMaxLength: 64,
            oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            "Password",
            "Users",
            "character varying(64)",
            maxLength: 64,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255,
            oldNullable: true);

        migrationBuilder.AddColumn<string>(
            "NormalizedUsername",
            "Users",
            "character varying(255)",
            maxLength: 255,
            nullable: false,
            defaultValue: "");

        migrationBuilder.CreateIndex(
            "IX_Users_NormalizedUsername",
            "Users",
            "NormalizedUsername",
            unique: true);
    }
}