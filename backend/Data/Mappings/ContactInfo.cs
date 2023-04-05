using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;
using ProjectsManagement.Data.Configurations;

namespace ProjectsManagement.Data.Mappings;

public class ContactInfoMap : BaseEntityConfiguration<ContactInfo>
{
    public new void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        builder.Property(x => x.Value).IsRequired().HasColumnName("Value").HasMaxLength(255);
        builder.HasOne(x => x.Type);
    }
}