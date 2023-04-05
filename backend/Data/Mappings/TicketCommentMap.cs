
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;
using ProjectsManagement.Data.Configurations;

namespace ProjectsManagement.Data.Mappings;

public class TicketCommentMap : BaseEntityConfiguration<TicketComment>
{
    public new void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        builder.Property(x => x.Text).IsRequired().HasColumnName("Text");
        builder.HasOne(x => x.Author);
        builder.HasOne(x => x.Ticket);


    }
}
