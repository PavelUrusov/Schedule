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
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Username).IsUnique();
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Password).IsRequired(false).HasMaxLength(64);
        builder.Property(u => u.RegistrationDate).IsRequired();
        builder.HasMany(u => u.WorkSchemas).WithOne(ws => ws.User).HasForeignKey(ws => ws.UserId);
        builder.HasMany(u => u.WorkObjects).WithOne(wo => wo.User).HasForeignKey(wo => wo.UserId);
    }
}