using dtaplace.Models;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.Services.Rooms;

public class RoomService(DTAPlaceDbContext ctx) : IRoomService
{
    public async Task<int> CreateRoom(Room room)
    {
        ctx.Rooms.Add(room);
        await ctx.SaveChangesAsync();
        return room.ID;
    }

    public Task<Room?> GetRoom(int roomId)
    {
        return ctx.Rooms.Where(r => r.ID == roomId).FirstOrDefaultAsync();
    }
}