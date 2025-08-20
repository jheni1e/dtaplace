namespace dtaplace.UseCases.DeleteRoomUser;

public class DeleteRoomUserUseCase
{
    public async Task<Result<DeleteRoomUserResponse>> Do(DeleteRoomUserPayload payload)
    {
        return Result<DeleteRoomUserResponse>.Success(null);
    }
}