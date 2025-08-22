using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.GetRooms;
public class GetRoomsUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<GetRoomsResponse>> Do(GetRoomsPayload payload)
    {
        var rooms = await ctx.Rooms.ToListAsync();
        
        return Result<GetRoomsResponse>.Success(new GetRoomsResponse(rooms));
    }
}