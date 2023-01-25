using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Database.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.NormalizedEmail).IsUnique();
        builder.HasIndex(u => u.NormalizedUsername).IsUnique();
        builder.Property(u => u.NormalizedEmail).IsRequired().HasMaxLength(255);
        builder.Property(u => u.NormalizedUsername).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Password).IsRequired(false).HasMaxLength(64);
        builder.Property(u => u.RegistrationDate).IsRequired();
        builder.HasOne(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
        builder.HasMany(u => u.WorkSchemas).WithOne(ws => ws.User).HasForeignKey(ws => ws.UserId);
        builder.HasMany(u => u.WorkObjects).WithOne(wo => wo.User).HasForeignKey(wo => wo.UserId);
    }
}