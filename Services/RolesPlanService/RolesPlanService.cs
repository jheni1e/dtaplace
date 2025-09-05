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

    public async Task<bool> IsAdminOrOwner(int RoleID)
    {
        var role = await GetRole(RoleID);
        return role == RoomRole.Admin || role == RoomRole.Dono;
    }

    public async Task<PlanName> GetPlan(int PlanID)
    {
        var plan = await ctx.Plans.FindAsync(PlanID);

        return plan.Name switch
        {
            "Platinum" => PlanName.Platinum,
            "Gold" => PlanName.Gold,
            _ => PlanName.Free
        };
    }
}