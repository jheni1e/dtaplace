namespace dtaplace.UseCases.CreateRoom;

public class CreateProfileUseCase(
    IRoomService roomService,
    IPasswordService passwordService
)
{
    public async Task<Result<CreateRoomResponse>> Do(CreateRoomPayload payload)
    {
        return Result<CreateRoomResponse>.Success(null);
    }
}