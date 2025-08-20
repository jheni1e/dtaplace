using dtaplace.Models;

namespace dtaplace.Services.Rooms;

public interface IRoomService
{
    Task<int> CreateRoom(Room room);
    Task<Room> GetRoom(int roomId);
}