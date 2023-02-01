#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class AddPropertySaltToUser : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            "Salt",
            "Users",
            "character varying(16)",
            maxLength: 16,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "Salt",
            "Users");
    }
}