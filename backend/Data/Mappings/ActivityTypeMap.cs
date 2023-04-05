using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class ActivityTypeMap : BaseEntityConfiguration<ActivityType>
{
    public new void Configure(EntityTypeBuilder<ActivityType> builder)
    {
        builder.ToTable("ActivityType");

        builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
    }
}