using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SourceControlProject.Common.DatabaseConstraints;
using SourceControlProject.Data.Models.Entities.Repositories.Commits;
using SourceControlProject.Data.Models.Entities.Repositories.Issues;
using SourceControlProject.Data.Models.Entities.Users;

namespace SourceControlProject.Data.Models.Entities.Repositories;

public class Repository
{

    public Repository()
    {
        this.Id=Guid.NewGuid();
        this.CreatedAt=DateTime.UtcNow;
        this.Contributors = new HashSet<Contributor>();
        this.Issues = new HashSet<Issue>();
        this.Commits = new HashSet<Commit>();
        this.PullRequests=new HashSet<PullRequest>();
    }

    [Key]
    [Required] //Not needed as key makes it required, adding for visibility
    public Guid Id { get; set; }

    [Required]
    [MaxLength(RepositoryConstraints.MaxNameLength)]
    public string Name { get; set; } = null!;

    [MaxLength(RepositoryConstraints.MaxDescriptionLength)]
    public string? Description { get; set; }

    [Required]
    public bool IsPrivate { get; set; }

    [Required] 
    public DateTime CreatedAt { get; set; }

    //ToDo: Add relationship properties

    [Required]
    [ForeignKey(nameof(Owner))]
    public Guid OwnerId { get; set; }

    public ApplicationUser Owner { get; set; } = null!;

    public ICollection<Contributor> Contributors { get; set; }

    public ICollection<Issue> Issues { get; set; }

    public ICollection<Commit> Commits { get; set; }

    public ICollection<PullRequest> PullRequests { get; set; }

}