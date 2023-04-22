
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;
using ProjectsManagement.Data.Configurations;

namespace ProjectsManagement.Data.Mappings;

public class ProjectMap : BaseEntityConfiguration<Project>
{
    public new void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
        builder.Property(x => x.Release).IsRequired().HasColumnName("Release");

        builder.HasOne(x => x.Manager);
        builder.HasMany(x => x.Squads);
        builder.HasMany(x => x.Milestones);
        builder.HasMany(x => x.Issues).WithOne(x => x.Project).OnDelete(DeleteBehavior.Cascade);
    }
}
