using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SourceControlProject.Data.Models.Entities.Repositories.Commits;

namespace SourceControlProject.Data.Configurations;

public class CommitEntityConfiguration:IEntityTypeConfiguration<Commit>
{
    public void Configure(EntityTypeBuilder<Commit> builder)
    {
        builder.HasIndex(c => c.AuthorId);

        builder.HasIndex(c => c.CreatedAt);

        builder.HasIndex(c => c.RepositoryId);

        builder.HasOne(c => c.Repository)
            .WithMany(r => r.Commits)
            .HasForeignKey(c => c.RepositoryId)
            .OnDelete((DeleteBehavior.NoAction));
    }
}