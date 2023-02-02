#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class FixRegistrationDateProperty : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "RegistrationDate",
            "Users");

        migrationBuilder.AddColumn<long>(
            "RegistrationUnixTimeSecondsUtc",
            "Users",
            "bigint",
            nullable: false,
            defaultValue: 0L);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "RegistrationUnixTimeSecondsUtc",
            "Users");

        migrationBuilder.AddColumn<TimeSpan>(
            "RegistrationDate",
            "Users",
            "interval",
            nullable: false,
            defaultValue: new TimeSpan(0, 0, 0, 0, 0));
    }
}