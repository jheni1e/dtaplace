using dtaplace.Models;

namespace dtaplace.Services.Rooms;

public interface IRoomService
{
    Task<Room> GetRoom(int ID);
}