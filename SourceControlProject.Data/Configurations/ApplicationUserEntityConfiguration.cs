using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SourceControlProject.Data.Models.Entities.Users;

namespace SourceControlProject.Data.Configurations;

public class ApplicationUserEntityConfiguration:IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasIndex(u => u.UserName)
            .IsUnique();

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}