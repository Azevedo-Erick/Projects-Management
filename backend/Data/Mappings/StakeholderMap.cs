
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class StakeholderMap : IEntityTypeConfiguration<Stakeholder>
{
    public void Configure(EntityTypeBuilder<Stakeholder> builder)
    {
        throw new NotImplementedException();
    }
}
