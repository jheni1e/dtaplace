using dtaplace.Models;
using dtaplace.Services.Password;
using dtaplace.Services.Rooms;

namespace dtaplace.UseCases.CreateRoom;

public class CreateRoomUseCase(IRoomService roomService)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        var room = new Room
        {
            Name = payload.Name,
            Width = payload.Width,
            Height = payload.Height,
            Creator = payload.Creator
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