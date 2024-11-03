using System.ComponentModel.DataAnnotations;

namespace SourceControlProject.Data.Models.Entities.Repositories.Commits;

public class Commit
{

    public Commit()
    {
        this.Id= Guid.NewGuid();
        this.CreatedAt= DateTime.UtcNow;
    }

    [Key]
    [Required]// Added for visibility as the key data annotation makes it required
    public Guid Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    //ToDo: Add relationship properties

}