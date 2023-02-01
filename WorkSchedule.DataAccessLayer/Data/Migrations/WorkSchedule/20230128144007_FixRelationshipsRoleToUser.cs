#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class FixRelationshipsRoleToUser : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_Users_Roles_RoleId",
            "Users");

        migrationBuilder.DropIndex(
            "IX_Users_RoleId",
            "Users");

        migrationBuilder.DropColumn(
            "RoleId",
            "Users");

        migrationBuilder.CreateTable(
            "UserRoles",
            table => new
            {
                RolesId = table.Column<int>("integer", nullable: false),
                UsersId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => new { x.RolesId, x.UsersId });
                table.ForeignKey(
                    "FK_UserRoles_Roles_RolesId",
                    x => x.RolesId,
                    "Roles",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_UserRoles_Users_UsersId",
                    x => x.UsersId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_UserRoles_UsersId",
            "UserRoles",
            "UsersId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "UserRoles");

        migrationBuilder.AddColumn<int>(
            "RoleId",
            "Users",
            "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateIndex(
            "IX_Users_RoleId",
            "Users",
            "RoleId");

        migrationBuilder.AddForeignKey(
            "FK_Users_Roles_RoleId",
            "Users",
            "RoleId",
            "Roles",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}