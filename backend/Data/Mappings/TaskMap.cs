
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;
using Task = ProjectsManagement.Models.Task;

namespace ProjectsManagement.Data.Mappings;

public class TaskMap : BaseEntityConfiguration<Task>
{
    public new void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasColumnName("Title");
        builder.Property(x => x.Description).IsRequired().HasColumnName("Description");
        builder.Property(x => x.StartDate).IsRequired().HasColumnName("StartDate");
        builder.Property(x => x.ConclusionDate).IsRequired().HasColumnName("ConclusionDate");
        builder.Property(x => x.DeadLine).IsRequired().HasColumnName("DeadLine");

        builder.HasOne(x => x.Assigner);

        builder.HasMany(x => x.Issues);
        builder.HasMany(x => x.Tags);

    }
}
