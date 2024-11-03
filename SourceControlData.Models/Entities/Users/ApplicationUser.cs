using SourceControlProject.Common.DatabaseConstraints;
using System.ComponentModel.DataAnnotations;

namespace SourceControlProject.Data.Models.Entities.Users;

public class ApplicationUser
{
    public ApplicationUser()
    {
        this.Id = Guid.NewGuid();
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

    //ToDo: Add relationship properties
}