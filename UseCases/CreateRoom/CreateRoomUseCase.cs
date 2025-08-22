using dtaplace.Models;
using dtaplace.Services.Password;
using dtaplace.Services.Rooms;

namespace dtaplace.UseCases.CreateRoom;

public class CreateProfileUseCase(
    IRoomService roomService
)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        var room = new Room
        {
            Name = payload.Name,
            Width = payload.Width,
            Height = payload.Height
        };

        await roomService.CreateRoom(room);

        return Result<CreateRoomResponse>.Success(new());
    }
}