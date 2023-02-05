using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Database.EntityConfiguration;

public class WorkObjectConfiguration : IEntityTypeConfiguration<WorkObject>
{
    public void Configure(EntityTypeBuilder<WorkObject> builder)
    {
        builder.ToTable("WorkObjects");
        builder.HasKey(wo => wo.Id);
        builder.HasAlternateKey(wo => new { wo.Name, wo.Id });
        builder.HasIndex(wo => wo.Id);
        builder.Property(wo => wo.Name).IsRequired().HasMaxLength(255);
        builder.HasOne(wo => wo.User).WithMany(u => u.WorkObjects).HasForeignKey(wo => wo.UserId);
        builder.HasMany(wo => wo.Employees).WithOne(e => e.WorkObject).HasForeignKey(e => e.WorkObjectId);
    }
}