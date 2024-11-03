using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SourceControlProject.Data.Models.Entities.Repositories;

namespace SourceControlProject.Data.Configurations;

public class RepositoryEntityConfiguration:IEntityTypeConfiguration<Repository>
{
    public void Configure(EntityTypeBuilder<Repository> builder)
    {
        builder.HasIndex(r => r.Name);

        builder.HasIndex(r => r.IsPrivate);

        builder.HasIndex(r => r.CreatedAt);
    }
}