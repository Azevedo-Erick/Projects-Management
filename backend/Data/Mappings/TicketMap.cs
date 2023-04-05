
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class TicketMap : BaseEntityConfiguration<Ticket>
{
    public new void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasColumnName("Title");
        builder.Property(x => x.Description).IsRequired().HasColumnName("Description");
        builder.Property(x => x.ResolutionDate).IsRequired().HasColumnName("ResolutionDate");
        builder.HasOne(x => x.Author);
        builder.HasOne(x => x.Project);

    }
}
