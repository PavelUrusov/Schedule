using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Database.EntityConfiguration;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.ScheduleStart).IsRequired();
        builder.HasOne(s => s.Employee).WithMany(e => e.Schedules).HasForeignKey(s => s.EmployeeId);
        builder.HasOne(s => s.WorkSchema).WithMany(ws => ws.Schedules).HasForeignKey(s => s.WorkSchemaId);
    }
}