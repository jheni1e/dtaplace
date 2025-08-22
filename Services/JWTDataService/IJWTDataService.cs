using dtaplace.Models;

namespace dtaplace.Services.Slakk;

public interface IJWTDataService
{
    Task<string> GetUsername(User user);
    Task<Plan> GetPlan(User user);
}