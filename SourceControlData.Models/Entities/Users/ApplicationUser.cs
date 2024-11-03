using SourceControlProject.Common.DatabaseConstraints;
using System.ComponentModel.DataAnnotations;
using SourceControlProject.Data.Models.Entities.Repositories;
using SourceControlProject.Data.Models.Entities.Repositories.Issues;

namespace SourceControlProject.Data.Models.Entities.Users;

public class ApplicationUser
{
    public ApplicationUser()
    {
        this.Id = Guid.NewGuid();
        this.OwnedRepositories = new HashSet<Repository>();
        this.Contributions = new HashSet<Contributor>();
        this.IssuesCreated = new HashSet<Issue>();
        this.PullRequests= new HashSet<PullRequest>();
    }

    [Key]
    [Required] // Not needed as key makes it required as well
    public Guid Id { get; set; }


    [Required]
    [MaxLength(ApplicationUserConstraints.MaxUserNameLength)]
    public string UserName { get; set; } = null!;

    [Required]
    [MaxLength(ApplicationUserConstraints.MaxEmailAddressLength)]
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public ICollection<Repository> OwnedRepositories { get; set; }

    public ICollection<Contributor> Contributions { get; set; }

    public ICollection<Issue> IssuesCreated { get; set; }

    public ICollection<PullRequest> PullRequests { get; set; }
}