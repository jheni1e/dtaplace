using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.GetRoles;
public class GetRolesUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<GetRolesResponse>> Do(GetRolesPayload? payload)
    {
        var roles = await ctx.Roles.ToListAsync();
        
        return Result<GetRolesResponse>.Success(new GetRolesResponse(roles));
    }
}