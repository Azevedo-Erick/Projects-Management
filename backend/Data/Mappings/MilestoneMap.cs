using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class MilestoneMap : IEntityTypeConfiguration<Milestone>
{
    public void Configure(EntityTypeBuilder<Milestone> builder)
    {
        throw new NotImplementedException();
    }
}