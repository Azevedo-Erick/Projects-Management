using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;
using ProjectsManagement.Data.Configurations;

namespace ProjectsManagement.Data.Mappings;

public class EmployeeMap : BaseEntityConfiguration<Employee>
{
    public new void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasOne(x => x.Person);
        builder.HasMany(x => x.Tasks).WithMany(x => x.AssignedTo).UsingEntity<Dictionary<string, object>>(
            "EmployeeTask",
            Employee => Employee.HasOne<Models.Task>().WithMany().OnDelete(DeleteBehavior.Cascade),
            Task => Task.HasOne<Employee>().WithMany().OnDelete(DeleteBehavior.Cascade)
        );
    }
}