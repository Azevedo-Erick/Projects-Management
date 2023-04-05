
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;
using ProjectsManagement.Data.Configurations;

namespace ProjectsManagement.Data.Mappings;

public class RoleMap : BaseEntityConfiguration<Role>
{
    public new void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(x => x.Permissions);

    }
}
