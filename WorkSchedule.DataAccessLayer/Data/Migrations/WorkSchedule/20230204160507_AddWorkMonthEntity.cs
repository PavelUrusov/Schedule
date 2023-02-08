#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class AddWorkMonthEntity : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            "WorkMonthId",
            "Schedules",
            "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateTable(
            "WorkMonths",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Year = table.Column<int>("integer", nullable: false),
                Month = table.Column<int>("integer", nullable: false),
                WorkObjectId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WorkMonths", x => x.Id);
                table.UniqueConstraint("AK_WorkMonths_Month_Year_WorkObjectId",
                    x => new { x.Month, x.Year, x.WorkObjectId });
                table.ForeignKey(
                    "FK_WorkMonths_WorkObjects_WorkObjectId",
                    x => x.WorkObjectId,
                    "WorkObjects",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_Schedules_WorkMonthId",
            "Schedules",
            "WorkMonthId");

        migrationBuilder.CreateIndex(
            "IX_RefreshTokens_Token",
            "RefreshTokens",
            "Token");

        migrationBuilder.CreateIndex(
            "IX_WorkMonths_WorkObjectId",
            "WorkMonths",
            "WorkObjectId");

        migrationBuilder.AddForeignKey(
            "FK_Schedules_WorkMonths_WorkMonthId",
            "Schedules",
            "WorkMonthId",
            "WorkMonths",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_Schedules_WorkMonths_WorkMonthId",
            "Schedules");

        migrationBuilder.DropTable(
            "WorkMonths");

        migrationBuilder.DropIndex(
            "IX_Schedules_WorkMonthId",
            "Schedules");

        migrationBuilder.DropIndex(
            "IX_RefreshTokens_Token",
            "RefreshTokens");

        migrationBuilder.DropColumn(
            "WorkMonthId",
            "Schedules");
    }
}