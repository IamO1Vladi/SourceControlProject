using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SourceControlProject.Data.Models.Entities.Repositories;

namespace SourceControlProject.Data.Configurations;

public class PullRequestEntityConfiguration:IEntityTypeConfiguration<PullRequest>
{
    public void Configure(EntityTypeBuilder<PullRequest> builder)
    {
        builder.HasIndex(pr => pr.Status);

        builder.HasIndex(pr => pr.CreatedAt);

        builder.HasIndex(pr => pr.RepositoryId);

        builder.HasOne(pr => pr.Repository)
            .WithMany(r => r.PullRequests)
            .HasForeignKey(pr => pr.RepositoryId)
            .OnDelete((DeleteBehavior.NoAction));
    }
}