
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

using ProjectsManagement.Data.Configurations;
namespace ProjectsManagement.Data.Mappings;

public class SquadMap : BaseEntityConfiguration<Squad>
{
    public new void Configure(EntityTypeBuilder<Squad> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
        builder.HasMany(x => x.Team);


    }
}
