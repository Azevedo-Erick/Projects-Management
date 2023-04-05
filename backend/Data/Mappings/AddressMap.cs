using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class AddressMap : BaseEntityConfiguration<Address>
{
    public new void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.Street).IsRequired().HasColumnName("Description").HasMaxLength(255);
        builder.Property(x => x.Number).IsRequired().HasColumnName("Number").HasMaxLength(255);
        builder.Property(x => x.Complement).IsRequired().HasColumnName("Complement");
        builder.Property(x => x.ZipCode).IsRequired().HasColumnName("ZipCode").HasMaxLength(255);
        builder.HasOne(x => x.City);

    }
}