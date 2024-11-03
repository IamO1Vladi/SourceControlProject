using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SourceControlProject.Data.Models.Entities.Repositories.Issues;

namespace SourceControlProject.Data.Configurations;

public class IssueTagEntityConfiguration:IEntityTypeConfiguration<IssueTag>
{
    public void Configure(EntityTypeBuilder<IssueTag> builder)
    {
        builder
            .HasKey(it => new { it.IssueId, it.TagId });

        builder
            .HasOne(it => it.Issue)
            .WithMany(i => i.Tags)
            .HasForeignKey(it => it.IssueId);

        builder
            .HasOne(it => it.Tag)
            .WithMany(t => t.Issues)
            .HasForeignKey(it => it.TagId);
    }
}