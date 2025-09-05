using dtaplace.Models;

namespace dtaplace.Services.RolePlanService;

public class RolesPlanService : IRolesPlanService
{
    public Task<PlanInfo> GetPlan(User user)
    {
        var planInfo = new PlanInfo
        {
            Name = user.Plan.Name,
            ID = user.Plan.ID,
            Secs2Paint = user.Plan.Secs2Paint,
            MaxRoom = user.Plan.MaxRoom
        };

        return Task.FromResult(planInfo);
    }

    public Task<RoleInfo> GetRole(User user)
    {
        throw new NotImplementedException();
    }
}