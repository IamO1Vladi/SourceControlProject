using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SourceControlProject.Data.Models.Entities.Users;

namespace SourceControlProject.Data.Models.Entities.Repositories.Commits;

public class Commit
{

    public Commit()
    {
        this.Id= Guid.NewGuid();
        this.CreatedAt= DateTime.UtcNow;
        this.FileModifications = new HashSet<FileModification>();
    }

    [Key]
    [Required]// Added for visibility as the key data annotation makes it required
    public Guid Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    //ToDo: Add relationship properties

    [Required]
    [ForeignKey(nameof(Repository))]
    public Guid RepositoryId { get; set; }

    public Repository Repository { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Author))]
    public Guid AuthorId { get; set; }

    public ApplicationUser Author { get; set; } = null!;

    public ICollection<FileModification> FileModifications { get; set; }
 
}