using System.ComponentModel.DataAnnotations;
using SourceControlProject.Common.DatabaseConstraints;
using SourceControlProject.Data.Models.Enums;

namespace SourceControlProject.Data.Models.Entities.Repositories.Issues;

public class Issue
{

    public Issue()
    {
        Id = Guid.NewGuid();
        this.CreatedAt = DateTime.UtcNow;
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

}