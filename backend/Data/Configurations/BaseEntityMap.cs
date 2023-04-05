using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Configurations;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValue(DateTime.Now);
        builder.Property(e => e.UpdatedAt).IsRequired().ValueGeneratedOnAddOrUpdate().HasDefaultValue(DateTime.Now);
        builder.Property(e => e.Version).IsRequired().IsConcurrencyToken();
    }

}