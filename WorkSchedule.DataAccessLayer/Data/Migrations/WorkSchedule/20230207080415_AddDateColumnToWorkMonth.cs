#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class AddDateColumnToWorkMonth : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropUniqueConstraint(
            "AK_WorkMonths_Month_Year_WorkObjectId",
            "WorkMonths");

        migrationBuilder.DropIndex(
            "IX_WorkMonths_WorkObjectId",
            "WorkMonths");

        migrationBuilder.DropColumn(
            "Month",
            "WorkMonths");

        migrationBuilder.DropColumn(
            "Year",
            "WorkMonths");

        migrationBuilder.AddColumn<DateOnly>(
            "Date",
            "WorkMonths",
            "date",
            nullable: false,
            defaultValue: new DateOnly(1, 1, 1));

        migrationBuilder.AddUniqueConstraint(
            "AK_WorkMonths_WorkObjectId_Date",
            "WorkMonths",
            new[] { "WorkObjectId", "Date" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropUniqueConstraint(
            "AK_WorkMonths_WorkObjectId_Date",
            "WorkMonths");

        migrationBuilder.DropColumn(
            "Date",
            "WorkMonths");

        migrationBuilder.AddColumn<int>(
            "Month",
            "WorkMonths",
            "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<int>(
            "Year",
            "WorkMonths",
            "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddUniqueConstraint(
            "AK_WorkMonths_Month_Year_WorkObjectId",
            "WorkMonths",
            new[] { "Month", "Year", "WorkObjectId" });

        migrationBuilder.CreateIndex(
            "IX_WorkMonths_WorkObjectId",
            "WorkMonths",
            "WorkObjectId");
    }
}