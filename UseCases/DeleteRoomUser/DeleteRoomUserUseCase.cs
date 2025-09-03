using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.DeleteRoomUser;

public class DeleteRoomUserUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<DeleteRoomUserResponse>> Do(DeleteRoomUserPayload payload)
    {
        var room = await ctx.UserRooms.SingleOrDefaultAsync(r => r.ID == payload.RoomID && r.UserID == payload.UserID);

        if (room is null)
        {
            return Result<DeleteRoomUserResponse>.Fail("Usuário ou sala não encontrado!");
        }

        ctx.UserRooms.Remove(room);
        await ctx.SaveChangesAsync();

        return Result<DeleteRoomUserResponse>.Success(null);

        //Donos e Administradores podem remover outros usuários. Donos podem remover Administradores, mas não o contrário
    }
}