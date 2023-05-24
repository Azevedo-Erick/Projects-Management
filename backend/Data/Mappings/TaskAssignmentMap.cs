using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class TaskAssignmentMap : IEntityTypeConfiguration<TaskAssignment>
{
    public void Configure(EntityTypeBuilder<TaskAssignment> builder)
    {
        builder.HasKey(pt => new { pt.MemberId, pt.TaskId });

        builder.HasOne(pt => pt.Member)
            .WithMany(p => p.Tasks)
            .HasForeignKey(pt => pt.MemberId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(pt => pt.Task)
            .WithMany(t => t.Assignments)
            .HasForeignKey(pt => pt.TaskId).OnDelete(DeleteBehavior.NoAction);
    }
}
