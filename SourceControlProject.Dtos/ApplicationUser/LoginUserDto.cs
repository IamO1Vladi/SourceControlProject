using System.ComponentModel.DataAnnotations;
using SourceControlProject.Common.DatabaseConstraints;

namespace SourceControlProject.Dtos.ApplicationUser;

public class LoginUserDto
{
    [Required]
    [MaxLength(ApplicationUserConstraints.MaxUserNameLength)]
    public string UserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}