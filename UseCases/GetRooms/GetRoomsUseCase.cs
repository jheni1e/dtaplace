namespace dtaplace.UseCases.GetRooms;
public class GetRoomsUseCase
{
    public async Task<Result<GetRoomsResponse>> Do(GetRoomsPayload payload)
    {
        return Result<GetRoomsResponse>.Success(null);
    }
}