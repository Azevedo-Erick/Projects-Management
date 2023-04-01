using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class ContactTypeMap : IEntityTypeConfiguration<ContactType>
{
    public void Configure(EntityTypeBuilder<ContactType> builder)
    {
        throw new NotImplementedException();
    }
}