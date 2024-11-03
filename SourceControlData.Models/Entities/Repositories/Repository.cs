using System.ComponentModel.DataAnnotations;
using SourceControlProject.Common.DatabaseConstraints;

namespace SourceControlProject.Data.Models.Entities.Repositories;

public class Repository
{

    public Repository()
    {
        this.Id=Guid.NewGuid();
        this.CreatedAt=DateTime.UtcNow;
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

}