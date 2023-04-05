
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;
using ProjectsManagement.Data.Configurations;

namespace ProjectsManagement.Data.Mappings;

public class TagMap : BaseEntityConfiguration<Tag>
{
    public new void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasColumnName("Title");
        builder.Property(x => x.HexColor).IsRequired().HasColumnName("HexColor");

    }
}
