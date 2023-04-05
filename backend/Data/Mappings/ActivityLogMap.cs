using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class ActivityLogMap : BaseEntityConfiguration<ActivityLog>
{
    public new void Configure(EntityTypeBuilder<ActivityLog> builder)
    {
        builder.ToTable("ActivityLog");

        builder.Property(x => x.Description).IsRequired().HasColumnName("Description").HasMaxLength(255);
        builder.Property(x => x.Timestamp).ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.HasOne(x => x.Person);
        builder.HasOne(x => x.ActivityType).WithMany(x => x.Logs).IsRequired();
    }
}