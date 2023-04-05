
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Data.Configurations;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Mappings;

public class PersonMap : BaseEntityConfiguration<Person>
{
    public new void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(x => x.Email).IsRequired().HasColumnName("Email");
        builder.Property(x => x.PasswordHash).IsRequired().HasColumnName("PasswordHash");
        builder.Property(x => x.DateOfBirth).IsRequired().HasColumnName("DateOfBirth");
        builder.Property(x => x.ProfileImage).IsRequired().HasColumnName("ProfileImage");
        builder.HasOne(x => x.Role);
        builder.HasOne(x => x.Address);
        builder.HasMany(x => x.Contacts);



    }
}
