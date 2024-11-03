using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SourceControlProject.Data.Configurations;
using SourceControlProject.Data.Models.Entities.Repositories;
using SourceControlProject.Data.Models.Entities.Repositories.Commits;
using SourceControlProject.Data.Models.Entities.Repositories.Issues;
using SourceControlProject.Data.Models.Entities.Users;

namespace SourceControlProject.Data;

public class SourceControlProjectDbContext:DbContext
{

    public SourceControlProjectDbContext()
    {
        
    }

    public SourceControlProjectDbContext(DbContextOptions options)
        : base(options)
    {

    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

    public DbSet<Repository> Repositories { get; set; } = null!;

    public DbSet<PullRequest> PullRequests { get; set; } = null!;

    public DbSet<Contributor> Contributors { get; set; } = null!;

    public DbSet<Tag> Tags { get; set; } = null!;

    public DbSet<IssueTag> IssuesTags { get; set; } = null!;

    public DbSet<Issue> Issues { get; set; } = null!;

    public DbSet<FileModification> FileModifications { get; set; } = null!;

    public DbSet<Commit> Commits { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly configAssembly = Assembly.GetAssembly(typeof(ApplicationUserEntityConfiguration)) ??
                                  Assembly.GetExecutingAssembly();

        modelBuilder.ApplyConfigurationsFromAssembly(configAssembly);


        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        Assembly currentAssembly= Assembly.GetExecutingAssembly();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-IFTT7UI\\SQLEXPRESS;Database=SourceControll;Integrated Security=True");
        }
        
        base.OnConfiguring(optionsBuilder);
    }
}