using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.GetPixels;

public class GetPixelsUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<GetPixelsResponse>> Do(GetPixelsPayload payload)
    {
        var room = await ctx.Rooms.SingleOrDefaultAsync(r => r.ID == payload.RoomID);

        if (room == null)
            return Result<GetPixelsResponse>.Fail("O quarto não existe.");

        var pixels = room.Pixels.ToList();

        if (pixels == null)
            return Result<GetPixelsResponse>.Fail("Não existem pixels.");

        return Result<GetPixelsResponse>.Success(new GetPixelsResponse(pixels));
        
        //Todos os usuários podem pedir todos os pixels pintados da tela para ver como ela está.
    }
}