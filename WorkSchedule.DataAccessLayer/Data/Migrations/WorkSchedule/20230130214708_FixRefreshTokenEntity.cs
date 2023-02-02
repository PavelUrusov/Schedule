#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkSchedule.DataAccessLayer.Data.Migrations.WorkSchedule;

public partial class FixRefreshTokenEntity : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            "IX_RefreshTokens_UserId",
            "RefreshTokens");

        migrationBuilder.DropColumn(
            "CreatedTokenUnixTimeSecondsUtc",
            "RefreshTokens");

        migrationBuilder.RenameColumn(
            "ExpiresTokenUnixTimeSecondsUtc",
            "RefreshTokens",
            "ExpireAtUnixTimeSecUtc");

        migrationBuilder.AddColumn<bool>(
            "IsValid",
            "RefreshTokens",
            "boolean",
            nullable: false,
            defaultValue: false);

        migrationBuilder.CreateIndex(
            "IX_RefreshTokens_UserId",
            "RefreshTokens",
            "UserId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            "IX_RefreshTokens_UserId",
            "RefreshTokens");

        migrationBuilder.DropColumn(
            "IsValid",
            "RefreshTokens");

        migrationBuilder.RenameColumn(
            "ExpireAtUnixTimeSecUtc",
            "RefreshTokens",
            "ExpiresTokenUnixTimeSecondsUtc");

        migrationBuilder.AddColumn<long>(
            "CreatedTokenUnixTimeSecondsUtc",
            "RefreshTokens",
            "bigint",
            maxLength: 255,
            nullable: false,
            defaultValue: 0L);

        migrationBuilder.CreateIndex(
            "IX_RefreshTokens_UserId",
            "RefreshTokens",
            "UserId",
            unique: true);
    }
}