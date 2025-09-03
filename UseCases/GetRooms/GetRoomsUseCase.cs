using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.GetRooms;
public class GetRoomsUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<GetRoomsResponse>> Do(GetRoomsPayload payload)
    {
        var rooms = await ctx.Rooms
            .Include(r => r.Creator)
            .Include(r => r.Name)
            .Where(r => r.Users.Any(u => u.ID == payload.UserID))
            .ToListAsync();

        if (!rooms.Any())
            return Result<GetRoomsResponse>.Fail("There are no rooms.");

        var response = rooms.Select(r => new RoomData
        {
            Name = r.Name,
            Creator = r.Creator.Username
        });
            
        return Result<GetRoomsResponse>.Success(new GetRoomsResponse(response));
        //Usuários logados podem ver todas as suas salas de desenho com seus respectivos nomes e quem criou aquela sala.
    }
}