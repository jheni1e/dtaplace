using dtaplace.Models;

namespace dtaplace.UseCases.GetRooms;
public record GetRoomsResponse (
    IEnumerable<RoomData> Rooms
);