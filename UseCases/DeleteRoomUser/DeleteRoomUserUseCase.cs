using dtaplace.Models;
using dtaplace.Services.RolePlanService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.DeleteRoomUser;

public class DeleteRoomUserUseCase(
    DTAPlaceDbContext ctx,
    IRolesPlanService rolesPlanService)
{
    public async Task<Result<DeleteRoomUserResponse>> Do(DeleteRoomUserPayload payload)
    {
        var room = await ctx.UserRooms.SingleOrDefaultAsync(r => r.ID == payload.RoomID && r.UserID == payload.UserID);
        var role = await rolesPlanService.GetRole(payload.UserID);


        if (!await rolesPlanService.IsAdminOrOwner(payload.RequesterID))
            return Result<DeleteRoomUserResponse>.Fail("Only the room owner and administrators can remove users from the room!");
            
        if (room is null)
            return Result<DeleteRoomUserResponse>.Fail("User / room not found!");

        ctx.UserRooms.Remove(room);
        await ctx.SaveChangesAsync();

        return Result<DeleteRoomUserResponse>.Success(null);

        //Donos e Administradores podem remover outros usuários. Donos podem remover Administradores, mas não o contrário
    }
}