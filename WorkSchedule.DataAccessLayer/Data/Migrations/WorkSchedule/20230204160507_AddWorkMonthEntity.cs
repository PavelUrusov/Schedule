using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule
{
    public partial class AddWorkMonthEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkMonthId",
                table: "Schedules",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkMonths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Month = table.Column<int>(type: "integer", nullable: false),
                    WorkObjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkMonths", x => x.Id);
                    table.UniqueConstraint("AK_WorkMonths_Month_Year_WorkObjectId", x => new { x.Month, x.Year, x.WorkObjectId });
                    table.ForeignKey(
                        name: "FK_WorkMonths_WorkObjects_WorkObjectId",
                        column: x => x.WorkObjectId,
                        principalTable: "WorkObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_WorkMonthId",
                table: "Schedules",
                column: "WorkMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_WorkMonths_WorkObjectId",
                table: "WorkMonths",
                column: "WorkObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_WorkMonths_WorkMonthId",
                table: "Schedules",
                column: "WorkMonthId",
                principalTable: "WorkMonths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_WorkMonths_WorkMonthId",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "WorkMonths");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_WorkMonthId",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens");

            migrationBuilder.DropColumn(
                name: "WorkMonthId",
                table: "Schedules");
        }
    }
}
