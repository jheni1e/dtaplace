using dtaplace.Models;
using dtaplace.Services.RolePlanService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.DeleteRoomUser;

public class DeleteRoomUserUseCase(
    DTAPlaceDbContext ctx,
    RolesPlanService rolesPlanService)
{
    public async Task<Result<DeleteRoomUserResponse>> Do(DeleteRoomUserPayload payload)
    {
        var room = await ctx.UserRooms.SingleOrDefaultAsync(r => r.ID == payload.RoomID && r.UserID == payload.UserID);
        var role = await rolesPlanService.GetRole(payload.UserID);

        if (role is not RoomRole.Admin || role is not RoomRole.Dono)
            return Result<DeleteRoomUserResponse>.Fail("Somente o host e os administradores da sala podem deletar usuários!");
            
        if (room is null)
            return Result<DeleteRoomUserResponse>.Fail("Usuário ou sala não encontrado!");

        ctx.UserRooms.Remove(room);
        await ctx.SaveChangesAsync();

        return Result<DeleteRoomUserResponse>.Success(null);

        //Donos e Administradores podem remover outros usuários. Donos podem remover Administradores, mas não o contrário
    }
}