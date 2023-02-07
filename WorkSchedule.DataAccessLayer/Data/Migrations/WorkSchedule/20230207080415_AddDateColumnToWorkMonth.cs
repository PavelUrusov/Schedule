using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule
{
    public partial class AddDateColumnToWorkMonth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_WorkMonths_Month_Year_WorkObjectId",
                table: "WorkMonths");

            migrationBuilder.DropIndex(
                name: "IX_WorkMonths_WorkObjectId",
                table: "WorkMonths");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "WorkMonths");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "WorkMonths");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "WorkMonths",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_WorkMonths_WorkObjectId_Date",
                table: "WorkMonths",
                columns: new[] { "WorkObjectId", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_WorkMonths_WorkObjectId_Date",
                table: "WorkMonths");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "WorkMonths");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "WorkMonths",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "WorkMonths",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_WorkMonths_Month_Year_WorkObjectId",
                table: "WorkMonths",
                columns: new[] { "Month", "Year", "WorkObjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_WorkMonths_WorkObjectId",
                table: "WorkMonths",
                column: "WorkObjectId");
        }
    }
}
