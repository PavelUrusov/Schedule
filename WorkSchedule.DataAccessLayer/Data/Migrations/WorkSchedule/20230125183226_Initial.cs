#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Users",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Email = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                Password = table.Column<string>("character varying(64)", maxLength: 64, nullable: true),
                Username = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                RegistrationDate = table.Column<TimeSpan>("interval", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

        migrationBuilder.CreateTable(
            "WorkObjects",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                UserId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WorkObjects", x => x.Id);
                table.ForeignKey(
                    "FK_WorkObjects_Users_UserId",
                    x => x.UserId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "WorkSchemas",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                Scheme = table.Column<int[]>("integer[]", maxLength: 31, nullable: false),
                StartTime = table.Column<TimeOnly>("time without time zone", nullable: false),
                EndTime = table.Column<TimeOnly>("time without time zone", nullable: false),
                UserId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_WorkSchemas", x => x.Id);
                table.ForeignKey(
                    "FK_WorkSchemas_Users_UserId",
                    x => x.UserId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "Employees",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Firstname = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                Surname = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                Lastname = table.Column<string>("character varying(255)", maxLength: 255, nullable: true),
                WorkObjectId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
                table.ForeignKey(
                    "FK_Employees_WorkObjects_WorkObjectId",
                    x => x.WorkObjectId,
                    "WorkObjects",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "Schedules",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                ScheduleStart = table.Column<DateOnly>("date", nullable: false),
                WorkSchemaId = table.Column<int>("integer", nullable: false),
                EmployeeId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Schedules", x => x.Id);
                table.ForeignKey(
                    "FK_Schedules_Employees_EmployeeId",
                    x => x.EmployeeId,
                    "Employees",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_Schedules_WorkSchemas_WorkSchemaId",
                    x => x.WorkSchemaId,
                    "WorkSchemas",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_Employees_WorkObjectId",
            "Employees",
            "WorkObjectId");

        migrationBuilder.CreateIndex(
            "IX_Schedules_EmployeeId",
            "Schedules",
            "EmployeeId");

        migrationBuilder.CreateIndex(
            "IX_Schedules_WorkSchemaId",
            "Schedules",
            "WorkSchemaId");

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

        migrationBuilder.CreateIndex(
            "IX_WorkObjects_Id",
            "WorkObjects",
            "Id");

        migrationBuilder.CreateIndex(
            "IX_WorkObjects_UserId",
            "WorkObjects",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_WorkSchemas_UserId",
            "WorkSchemas",
            "UserId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "Schedules");

        migrationBuilder.DropTable(
            "Employees");

        migrationBuilder.DropTable(
            "WorkSchemas");

        migrationBuilder.DropTable(
            "WorkObjects");

        migrationBuilder.DropTable(
            "Users");
    }
}