using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class CityMap : BaseEntityConfiguration<City>
{
    public new void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
        builder.HasOne(x => x.State);

    }
}