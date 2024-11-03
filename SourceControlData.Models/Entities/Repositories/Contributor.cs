using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SourceControlProject.Data.Models.Entities.Users;

namespace SourceControlProject.Data.Models.Entities.Repositories;

public class Contributor
{
    [Key]
    [Required]//Adding for visibility, the key data annotation makes it required
    public Guid Id { get; set; }

    [Required]
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }

    public ApplicationUser User { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Repository))]
    public Guid RepositoryId { get; set; }

    public Repository Repository { get; set; } = null!;

}