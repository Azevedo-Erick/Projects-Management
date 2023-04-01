
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class NotificationTypeMap : IEntityTypeConfiguration<NotificationType>
{
    public void Configure(EntityTypeBuilder<NotificationType> builder)
    {
        throw new NotImplementedException();
    }
}
