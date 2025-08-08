public class GetPixelsUseCase
{
    public async Task<Result<GetPixelsResponse>> Do (GetPixelsPayload payload)
    {
        return Result<GetPixelsResponse>.Success(null);
    }

}