using dtaplace.Models;

namespace dtaplace.Services.RolePlanService;


public interface IRolesPlanService
{
    Task<PlanInfo> GetPlan(User user);
    Task<string> GetRole(User user);
}