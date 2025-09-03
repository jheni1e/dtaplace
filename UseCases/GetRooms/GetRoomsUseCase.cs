using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.GetRooms;
public class GetRoomsUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<GetRoomsResponse>> Do(GetRoomsPayload payload)
    {
        var rooms = await ctx.Rooms.ToListAsync();

        return Result<GetRoomsResponse>.Success(new GetRoomsResponse(rooms));
        //Usuários logados podem ver todas as suas salas de desenho com seus respectivos nomes e quem criou aquela sala.
    }
}