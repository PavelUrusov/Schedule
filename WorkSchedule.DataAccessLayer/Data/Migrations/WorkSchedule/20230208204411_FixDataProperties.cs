#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class FixDataProperties : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            "StartTime",
            "WorkSchemas",
            "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(TimeOnly),
            oldType: "time without time zone");

        migrationBuilder.AlterColumn<string>(
            "EndTime",
            "WorkSchemas",
            "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(TimeOnly),
            oldType: "time without time zone");

        migrationBuilder.AlterColumn<string>(
            "Date",
            "WorkMonths",
            "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(DateOnly),
            oldType: "date");

        migrationBuilder.AlterColumn<string>(
            "ScheduleStart",
            "Schedules",
            "character varying(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(DateOnly),
            oldType: "date");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<TimeOnly>(
            "StartTime",
            "WorkSchemas",
            "time without time zone",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<TimeOnly>(
            "EndTime",
            "WorkSchemas",
            "time without time zone",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateOnly>(
            "Date",
            "WorkMonths",
            "date",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);

        migrationBuilder.AlterColumn<DateOnly>(
            "ScheduleStart",
            "Schedules",
            "date",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(255)",
            oldMaxLength: 255);
    }
}