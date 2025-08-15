using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.Services.Profiles;

public class ProfileService(DTAPlaceDbContext ctx) : IProfileService
{
    public async Task<int> CreateProfile(User user)
    {
        ctx.Users.Add(user);
        await ctx.SaveChangesAsync();
        return user.ID;
    }

    public Task<User> GetProfile(string username)
    {
        return ctx.Users.Where(p => p.Username == username).FirstOrDefaultAsync();
    }
}