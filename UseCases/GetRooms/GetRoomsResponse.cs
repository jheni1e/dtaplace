using dtaplace.Models;

namespace dtaplace.UseCases.GetRooms;
public record GetRoomsResponse (
    List<Room> Rooms
);