using System.ComponentModel.DataAnnotations;
using SourceControlProject.Common.DatabaseConstraints;

namespace SourceControlProject.Data.Models.Entities.Repositories.Issues;

public class Tag
{
    public Tag()
    {
        this.Id = Guid.NewGuid();
    }

    [Key]
    [Required]//Adding for visibility, the key annotation already gives it required
    public Guid Id { get; set; }

    [Required]
    [MaxLength(TagConstraints.MaxNameLength)]
    public string Name { get; set; } = null!;

    //ToDo: Add relationship properties
}