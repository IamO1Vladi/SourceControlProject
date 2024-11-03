using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SourceControlProject.Common.DatabaseConstraints;
using SourceControlProject.Data.Models.Enums;

namespace SourceControlProject.Data.Models.Entities.Repositories.Commits;

public class FileModification
{

    public FileModification()
    {
        this.Id = Guid.NewGuid();
    }

    [Key]
    [Required] //Adding for visibility/ the key annotation makes it required
    public Guid Id { get; set; }

    [Required]
    [MaxLength(FileModificationConstraints.MaxFileNameLength)]
    public string FileName { get; set; } = null!;

    [Required]
    public string FileDifference { get; set; }=null!;

    [Required]
    public ModificationType Type { get; set; }

    //ToDo: Add relationship properties

    [Required]
    [ForeignKey(nameof(Commit))]
    public Guid CommitId { get; set; }

    public Commit Commit { get; set; } = null!;
}