using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Database.EntityConfiguration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Firstname).IsRequired().HasMaxLength(255);
        builder.Property(e => e.Surname).IsRequired().HasMaxLength(255);
        builder.Property(e => e.Lastname).IsRequired(false).HasMaxLength(255);
        builder.HasOne(e => e.WorkObject).WithMany(wo => wo.Employees).HasForeignKey(e => e.WorkObjectId);
        builder.HasMany(e => e.Schedules).WithOne(s => s.Employee).HasForeignKey(s => s.EmployeeId);
    }
}