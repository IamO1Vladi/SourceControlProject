using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SourceControlProject.Data.Models.Entities.Repositories;

namespace SourceControlProject.Data.Configurations;

public class ContributorEntityConfiguration:IEntityTypeConfiguration<Contributor>
{
    public void Configure(EntityTypeBuilder<Contributor> builder)
    {
        builder.HasIndex(c => c.UserId);

        builder.HasIndex(c => c.RepositoryId);

        builder.HasKey(c => new { c.UserId, c.RepositoryId });

        builder.HasOne(c => c.User)
            .WithMany(u => u.Contributions)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Repository)
            .WithMany(r => r.Contributors)
            .HasForeignKey(c => c.RepositoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}