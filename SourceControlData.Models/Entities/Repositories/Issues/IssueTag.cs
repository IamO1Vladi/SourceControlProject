using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SourceControlProject.Data.Models.Entities.Repositories.Issues;

public class IssueTag
{
    public IssueTag()
    {
        this.Id= Guid.NewGuid();
    }

    [Key]
    [Required]//This is for visibility, the key data annotation already makes it required
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(Issue))]
    public Guid IssueId { get; set; }

    public Issue Issue { get; set; }

    [Required]
    [ForeignKey(nameof(Tag))]
    public Guid TagId { get; set; }

    public Tag Tag { get; set; }
}