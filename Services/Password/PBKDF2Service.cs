using Microsoft.AspNetCore.Identity;

namespace dtaplace.Services.Password;

public class PBKDF2Service : IPasswordService
{
    readonly PasswordHasher<string> hasher = new();
    public bool Compare(string password, string hash)
    {
        var result = hasher.VerifyHashedPassword(password, hash, password);
        return result == PasswordVerificationResult.Success;
    }

    public string Hash(string password)
        => hasher.HashPassword(password, password);
}