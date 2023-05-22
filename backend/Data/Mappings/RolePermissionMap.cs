using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class RolePermissionMap : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(pt => new { pt.PermissionId, pt.RoleId });

        builder.HasOne(pt => pt.Permission)
            .WithMany(p => p.Roles)
            .HasForeignKey(pt => pt.PermissionId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(pt => pt.Role)
            .WithMany(t => t.Permissions)
            .HasForeignKey(pt => pt.RoleId).OnDelete(DeleteBehavior.NoAction);
    }
}
