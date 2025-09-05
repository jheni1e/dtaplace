using dtaplace.Models;

namespace dtaplace.Services.RolePlanService;

public class RolesPlanService(DTAPlaceDbContext ctx) : IRolesPlanService
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

    public async Task<RoomRole> GetRole(int RoleID)
    {
        var role = await ctx.Roles.FindAsync(RoleID);

        return role.Rolename switch
        {
            "Dono" => RoomRole.Dono,
            "Admin" => RoomRole.Admin,
            "Pintor" => RoomRole.Pintor,
            _ => RoomRole.Plateia
        };
    }
}