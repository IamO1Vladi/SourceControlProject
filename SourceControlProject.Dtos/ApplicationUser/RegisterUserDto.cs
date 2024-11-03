using System.ComponentModel.DataAnnotations;
using SourceControlProject.Common.DatabaseConstraints;

namespace SourceControlProject.Dtos;

public class RegisterUserDto
{
    [Required]
    [MaxLength(ApplicationUserConstraints.MaxUserNameLength)]
    public string UserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    [MaxLength(ApplicationUserConstraints.MaxEmailAddressLength)]
    public string Email { get; set; } = null!;
}