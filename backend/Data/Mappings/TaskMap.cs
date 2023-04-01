
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;
using Task = ProjectsManagement.Models.Task;

namespace ProjectsManagement.Data.Mappings;

public class TaskMap : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        throw new NotImplementedException();
    }
}
