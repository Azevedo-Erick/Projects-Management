using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class MilestoneMap : BaseEntityConfiguration<Milestone>
{
    public new void Configure(EntityTypeBuilder<Milestone> builder)
    {


        builder.Property(x => x.Title).IsRequired().HasColumnName("Title").HasMaxLength(255);
        builder.Property(x => x.Description).IsRequired().HasColumnName("Description");
        builder.Property(x => x.StartDate).HasColumnType("date").IsRequired().HasColumnName("StartDate");
        builder.Property(x => x.DeadLine).HasColumnType("date").IsRequired().HasColumnName("DeadLine");

    }
}