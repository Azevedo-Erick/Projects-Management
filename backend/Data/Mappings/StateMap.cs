
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Data.Seeds;

namespace ProjectsManagement.Data.Mappings;

public class StateMap : BaseEntityConfiguration<State>
{
    public new void Configure(EntityTypeBuilder<State> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasColumnName("Name");
        builder.HasOne(x => x.Country);
        builder.HasData(StateSeed.GetStates());

    }
}
