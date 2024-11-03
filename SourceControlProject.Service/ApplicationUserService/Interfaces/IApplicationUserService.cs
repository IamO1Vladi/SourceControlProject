namespace SourceControlProject.Service.ApplicationUserService.Interfaces;

public interface IApplicationUserService
{
    public Task<bool> RegisterUserAsync(string userName,string email,string password);

    public Task<bool> ValidateUserCredentialsAsync(string userName, string password);
}