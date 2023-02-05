using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule
{
    public partial class AddAlternateKeyToWorkObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_WorkObjects_Name_Id",
                table: "WorkObjects",
                columns: new[] { "Name", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_WorkObjects_Name_Id",
                table: "WorkObjects");
        }
    }
}
