using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Database.EntityConfiguration;

public class WorkMonthConfiguration : IEntityTypeConfiguration<WorkMonth>
{
    public void Configure(EntityTypeBuilder<WorkMonth> builder)
    {
        builder.ToTable("WorkMonths");
        builder.HasKey(wm => wm.Id);
        builder.HasAlternateKey(wm => new { wm.WorkObjectId, wm.Date });
        builder.Property(wm => wm.Date).IsRequired().HasMaxLength(255);
        builder.HasMany(wm => wm.Schedules).WithOne(s => s.WorkMonth).HasForeignKey(s => s.WorkMonthId);
        builder.HasOne(wm => wm.WorkObject).WithMany(wo => wo.WorkMonths).HasForeignKey(wm => wm.WorkObjectId);
    }
}