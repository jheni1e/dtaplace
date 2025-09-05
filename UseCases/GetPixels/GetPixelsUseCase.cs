using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.GetPixels;

public class GetPixelsUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<GetPixelsResponse>> Do(GetPixelsPayload payload)
    {
        var room = await ctx.Rooms.SingleOrDefaultAsync(r => r.ID == payload.RoomID);
        if (room == null)
            return Result<GetPixelsResponse>.Fail("Room doesn't exist.");

        var pixels = room.Pixels.ToList();
        if (pixels == null)
            return Result<GetPixelsResponse>.Fail("There are no pixels.");

        return Result<GetPixelsResponse>.Success(new GetPixelsResponse(pixels));
        //Todos os usuários podem pedir todos os pixels pintados da tela para ver como ela está.
    }
}