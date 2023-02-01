#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class AddRefreshTokenEntity : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "RefreshTokens",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Token = table.Column<string>("character varying(255)", maxLength: 255, nullable: false),
                CreatedTokenUnixTimeSecondsUtc = table.Column<long>("bigint", maxLength: 255, nullable: false),
                ExpiresTokenUnixTimeSecondsUtc = table.Column<long>("bigint", maxLength: 255, nullable: false),
                UserId = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                table.ForeignKey(
                    "FK_RefreshTokens_Users_UserId",
                    x => x.UserId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_RefreshTokens_UserId",
            "RefreshTokens",
            "UserId",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "RefreshTokens");
    }
}