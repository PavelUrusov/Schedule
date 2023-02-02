#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class AddRoles : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            "IX_Users_Email",
            "Users");

        migrationBuilder.DropIndex(
            "IX_Users_Username",
            "Users");

        migrationBuilder.AddColumn<string>(
            "NormalizedEmail",
            "Users",
            "character varying(255)",
            maxLength: 255,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<string>(
            "NormalizedUsername",
            "Users",
            "character varying(255)",
            maxLength: 255,
            nullable: false,
            defaultValue: "");

        migrationBuilder.AddColumn<int>(
            "RoleId",
            "Users",
            "integer",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.CreateTable(
            "Roles",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                NormalizedName = table.Column<string>("character varying(255)", maxLength: 255, nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

        migrationBuilder.CreateIndex(
            "IX_Users_NormalizedEmail",
            "Users",
            "NormalizedEmail",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_Users_NormalizedUsername",
            "Users",
            "NormalizedUsername",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_Users_RoleId",
            "Users",
            "RoleId");

        migrationBuilder.CreateIndex(
            "IX_Roles_NormalizedName",
            "Roles",
            "NormalizedName",
            unique: true);

        migrationBuilder.AddForeignKey(
            "FK_Users_Roles_RoleId",
            "Users",
            "RoleId",
            "Roles",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            "FK_Users_Roles_RoleId",
            "Users");

        migrationBuilder.DropTable(
            "Roles");

        migrationBuilder.DropIndex(
            "IX_Users_NormalizedEmail",
            "Users");

        migrationBuilder.DropIndex(
            "IX_Users_NormalizedUsername",
            "Users");

        migrationBuilder.DropIndex(
            "IX_Users_RoleId",
            "Users");

        migrationBuilder.DropColumn(
            "NormalizedEmail",
            "Users");

        migrationBuilder.DropColumn(
            "NormalizedUsername",
            "Users");

        migrationBuilder.DropColumn(
            "RoleId",
            "Users");

        migrationBuilder.CreateIndex(
            "IX_Users_Email",
            "Users",
            "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_Users_Username",
            "Users",
            "Username",
            unique: true);
    }
}