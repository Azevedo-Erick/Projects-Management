
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class StakeholderMap : BaseEntityConfiguration<Stakeholder>
{
    public new void Configure(EntityTypeBuilder<Stakeholder> builder)
    {
        builder.HasOne(x => x.Person);
        builder.HasMany(x => x.Projects);


    }
}
