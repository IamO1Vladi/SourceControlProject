using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SourceControlProject.Common.DatabaseConstraints;
using SourceControlProject.Data.Models.Entities.Users;
using SourceControlProject.Data.Models.Enums;

namespace SourceControlProject.Data.Models.Entities.Repositories.Issues;

public class Issue
{

    public Issue()
    {
        Id = Guid.NewGuid();
        this.CreatedAt = DateTime.UtcNow;
        this.Tags = new HashSet<IssueTag>();
    }

    [Key]
    [Required] //Adding for visibility as the key annotation makes it required
    public Guid Id { get; set; }

    [Required]
    [MaxLength(IssueConstraints.MaxTitleLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(IssueConstraints.MaxDescriptionLength)]
    public string Description { get; set; } = null!;

    [Required]
    public IssueStatus Status { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    //ToDo: Add relationship properties

    [Required]
    [ForeignKey(nameof(Repository))]
    public Guid RepositoryId { get; set; }

    public Repository Repository { get; set; }

    [Required]
    [ForeignKey(nameof(Owner))]
    public Guid OwnerId { get; set; }

    public ApplicationUser Owner { get; set; }

    public ICollection<IssueTag> Tags { get; set; }
}