
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class PermissionMap : BaseEntityConfiguration<Permission>
{
    public new void Configure(EntityTypeBuilder<Permission> builder)
    {

        builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
        builder.Property(x => x.Has).IsRequired().HasColumnName("Has");

    }
}
