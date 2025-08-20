using dtaplace.Models;

namespace dtaplace.UseCases.GetRooms;
public record GetRoomsResponse (
    ICollection<Room> Rooms
);