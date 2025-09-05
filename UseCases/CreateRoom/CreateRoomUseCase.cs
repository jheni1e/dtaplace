using dtaplace.Models;
using dtaplace.Services.Password;
using dtaplace.Services.Profiles;
using dtaplace.Services.Rooms;

namespace dtaplace.UseCases.CreateRoom;

public class CreateRoomUseCase(
    IRoomService roomService,
    IProfileService profileService
)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        var creator = await profileService.GetProfile(payload.CreatorUsername);
        if (creator is null)
            return Result<CreateRoomResponse>.Fail("User doesn't exist.");

        var room = new Room
        {
            Name = payload.Name,
            Width = payload.Width,
            Height = payload.Height,
            Creator = creator
        };

        await roomService.CreateRoom(room);

        return Result<CreateRoomResponse>.Success(new());

        //Usuários logados podem criar salas de desenho. Para isso definem o nome da sala e seu tamanho.
        // Existem limites de tamanho com base no tipo de usuário.
        // Usuários com plano Gratuito podem ter salas de até 64x64.
        // Usuários com plano Gold podem ter salas de até 128x128.
        // Usuários com plano Platinum podem ter salas de até 256x256.
    }
}