using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class IssueMap : BaseEntityConfiguration<Issue>
{
    public new void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasColumnName("Title").HasMaxLength(255);
        builder.Property(x => x.Text).IsRequired().HasColumnName("Text");
        builder.HasOne(x => x.Author);
        builder.HasOne(x => x.Task);


    }
}