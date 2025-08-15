using dtaplace.Models;

namespace dtaplace.Services.Profiles;

public interface IProfileService
{
    Task<int> CreateProfile(User profile);
    Task<User> GetProfile(string username);
}