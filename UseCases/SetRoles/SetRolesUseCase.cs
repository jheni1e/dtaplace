using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.SetRoles;

public class SetRolesUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<SetRolesResponse>> Do(SetRolesPayload payload)
    {
        var userroom = await ctx.UserRooms.SingleOrDefaultAsync(r => r.RoomID == payload.RoomID && r.UserID == payload.UserID);

        if (userroom is null)
            return Result<SetRolesResponse>.Fail("UserRoom não encontrado.");

        userroom.RoleID = payload.RoleID;
        await ctx.SaveChangesAsync();

        return Result<SetRolesResponse>.Success(null);
    }
}