using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class ContactTypeMap : BaseEntityConfiguration<ContactType>
{
    public new void Configure(EntityTypeBuilder<ContactType> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
    }
}