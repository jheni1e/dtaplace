using dtaplace.Models;

namespace dtaplace.Services.RolePlanService;


public interface IRolesPlanService
{
    Task<PlanInfo> GetPlan(User user);
    Task<RoleInfo> GetRole(User user);
}