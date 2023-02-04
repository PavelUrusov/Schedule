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
        builder.HasAlternateKey(wm => new { wm.Month, wm.Year, wm.WorkObjectId });
        builder.Property(wm => wm.Year).IsRequired();
        builder.Property(wm => wm.Month).IsRequired();
        builder.HasMany(wm => wm.Schedules).WithOne(s => s.WorkMonth).HasForeignKey(s => s.WorkMonthId);
        builder.HasOne(wm => wm.WorkObject).WithMany(wo => wo.WorkMonths).HasForeignKey(wm => wm.WorkObjectId);
    }
}