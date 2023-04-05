
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class NotificationMap : BaseEntityConfiguration<Notification>
{
    public new void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.Property(x => x.Message).IsRequired().HasColumnName("Message");
        builder.Property(x => x.IsRead).IsRequired().HasColumnName("IsRead");
        builder.HasOne(x => x.Type);
        builder.HasOne(x => x.Recipient);



    }
}
