
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class NotificationTypeMap : BaseEntityConfiguration<NotificationType>
{
    public new void Configure(EntityTypeBuilder<NotificationType> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name");

    }
}
