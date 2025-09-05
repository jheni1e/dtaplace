using dtaplace.Models;

namespace dtaplace.Services.RolePlanService;

public enum RoomRole
{
    Dono = 4,
    Admin = 3,
    Pintor = 2,
    Plateia = 1
}

public interface IRolesPlanService
{
    Task<PlanInfo> GetPlan(User user);
    Task<RoomRole> GetRole(int RoleID);
}