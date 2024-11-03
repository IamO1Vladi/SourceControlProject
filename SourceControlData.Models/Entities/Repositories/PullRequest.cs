using System.ComponentModel.DataAnnotations;
using SourceControlProject.Data.Models.Enums;

namespace SourceControlProject.Data.Models.Entities.Repositories;

public class PullRequest
{
    public PullRequest()
    {
        this.Id= Guid.NewGuid();
        this.CreatedAt= DateTime.UtcNow;
    }

    [Key]
    [Required]//Added for visibility/ the key data annotation already makes it required
    public Guid Id { get; set; }

    [Required]
    public PullRequestStatus Status { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    //ToDo: Add relationship properties
}