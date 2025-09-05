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

        //Donos e Administradores podem mudar permissões de outros usuários, isso é mudar entre Dono, Administrador, Pintor ou Plateia.
        // Contudo, eles não podem nunca prover a algo acima de seu cargo nem afetar alguém com um cargo igual ou superior.
        // Ou seja, um Dono não pode transformar outro Dono em Plateia.
        // Um Administrador não pode promover alguém a Dono ou reduzir o nível de outro Administrador.
    }
}