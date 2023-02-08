using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkSchedule.DataAccessLayer.Entities;

namespace WorkSchedule.DataAccessLayer.Database.EntityConfiguration;

public class WorkSchemaConfiguration : IEntityTypeConfiguration<WorkSchema>
{
    public void Configure(EntityTypeBuilder<WorkSchema> builder)
    {
        builder.ToTable("WorkSchemas");
        builder.HasKey(ws => ws.Id);
        builder.Property(ws => ws.Name).IsRequired().HasMaxLength(255);
        builder.Property(ws => ws.StartTime).IsRequired().HasMaxLength(255);
        builder.Property(ws => ws.EndTime).IsRequired().HasMaxLength(255);
        builder.Property(ws => ws.Scheme).IsRequired().HasMaxLength(31);
        builder.HasOne(ws => ws.User).WithMany(u => u.WorkSchemas).HasForeignKey(ws => ws.UserId);
        builder.HasMany(ws => ws.Schedules).WithOne(u => u.WorkSchema).HasForeignKey(u => u.WorkSchemaId);
    }
}