using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;


public class CountryMap : BaseEntityConfiguration<Country>
{
    public new void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
    }
}