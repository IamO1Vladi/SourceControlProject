using Microsoft.EntityFrameworkCore;
using SourceControlProject.Data;
using SourceControlProject.Data.Models.Entities.Users;
using SourceControlProject.Service.ApplicationUserService.Interfaces;
using System.Security.Cryptography;

namespace SourceControlProject.Service.ApplicationUserService;

public class ApplicationUserService:IApplicationUserService
{
    private readonly SourceControlProjectDbContext context;

    public ApplicationUserService(SourceControlProjectDbContext dbContext)
    {
        this.context= dbContext;
    }

    public async Task<bool> RegisterUserAsync(string userName, string email, string password)
    {
        ApplicationUser? existingUser = await context.ApplicationUsers
            .FirstOrDefaultAsync(u => u.UserName == userName || u.Email == email);

        if (existingUser != null)
            return false; 

        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
            PasswordHash = HashPassword(password)
        };

        context.ApplicationUsers.Add(user);
        await context.SaveChangesAsync();

        return true; 
    }

    public async Task<bool> ValidateUserCredentialsAsync(string userName, string password)
    {
        ApplicationUser? user = await context.ApplicationUsers
            .FirstOrDefaultAsync(u => u.UserName == userName);

        if (user == null || VerifyPassword(password,user.PasswordHash))
            return false; 

        return true; // Valid credentials
    }

    private  string HashPassword(string password)
    {
        
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] salt = new byte[16];
            rng.GetBytes(salt);

           
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000)) 
            {
                byte[] hash = pbkdf2.GetBytes(20); 

                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);


                return Convert.ToBase64String(hashBytes);
            }
        }
    }

    private bool VerifyPassword(string password, string storedHash)
    {
       
        byte[] hashBytes = Convert.FromBase64String(storedHash);

        
        byte[] salt = new byte[16];
        Array.Copy(hashBytes, 0, salt, 0, 16);

       
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000))
        {
            byte[] hash = pbkdf2.GetBytes(20);

           
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
        }

        return true;
    }
}