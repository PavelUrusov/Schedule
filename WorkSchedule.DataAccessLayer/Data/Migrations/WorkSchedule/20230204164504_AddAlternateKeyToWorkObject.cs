#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class AddAlternateKeyToWorkObject : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddUniqueConstraint(
            "AK_WorkObjects_Name_Id",
            "WorkObjects",
            new[] { "Name", "Id" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropUniqueConstraint(
            "AK_WorkObjects_Name_Id",
            "WorkObjects");
    }
}