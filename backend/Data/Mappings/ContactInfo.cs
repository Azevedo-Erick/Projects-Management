using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class ContactInfoMap : IEntityTypeConfiguration<ContactInfo>
{
    public void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        throw new NotImplementedException();
    }
}