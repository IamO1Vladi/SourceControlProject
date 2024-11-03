using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SourceControlProject.Data.Models.Entities.Repositories.Issues;

namespace SourceControlProject.Data.Configurations;

public class IssueEntityConfiguration:IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.HasIndex(i => i.Status);

        builder.HasIndex(i => i.CreatedAt);

        builder.HasIndex(i => i.RepositoryId);

        builder.HasOne(i => i.Repository)
            .WithMany(r => r.Issues)
            .HasForeignKey(i => i.RepositoryId)
            .OnDelete((DeleteBehavior.NoAction));
    }
}