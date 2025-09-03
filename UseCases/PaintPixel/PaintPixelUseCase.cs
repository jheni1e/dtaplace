using dtaplace.Endpoints;
using dtaplace.Models;
using dtaplace.Services.Profiles;
using dtaplace.Services.Rooms;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.PaintPixel;

public class PaintPixelUseCase(
    DTAPlaceDbContext ctx,
    IProfileService profileService,
    IRoomService roomservice
)
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        //Um Dono, Administrador ou Pintor pode escolher pintar um pixel com uma posição (x, y) com uma cor qualquer RGB.
        // Mas cada usuário só pode pintar um pixel a cada 60 segundos.
        // Usuário Gold podem pintar a cada 50 segundos e usuários Platinum a cada 40 segundos.

        var user = await profileService.GetProfile(payload.Username);
        var room = await roomservice.GetRoom(payload.RoomID);

        var userRoom = ctx.UserRooms.Where(ur => ur.UserID == user.ID && ur.RoomID == room.ID).FirstOrDefaultAsync();
        if (userRoom is null)
            return Result<PaintPixelResponse>.Fail("Invalid room / user");

        var secs = await ctx.Users
            .Where(u => u.Username == payload.Username)
            .Select(u => u.Plan.Secs2Paint)
            .FirstOrDefaultAsync();

        if (DateTime.Now - user.LastPaint < TimeSpan.FromSeconds(secs))
            return Result<PaintPixelResponse>.Fail($"Pintou agorinha, espere mais {TimeSpan.FromSeconds(secs) - (DateTime.Now - user.LastPaint)}");
        
        var pixel = new Pixel
        {
            R = payload.R,
            G = payload.G,
            B = payload.B,
            Y = payload.Y,
            X = payload.X,
            RoomID = payload.RoomID,
            Room = room
        };

        ctx.Pixels.Add(pixel);
        user.LastPaint = DateTime.Now;
    
        await ctx.SaveChangesAsync();

        return Result<PaintPixelResponse>.Success(null);
    }
}