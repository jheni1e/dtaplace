namespace dtaplace.UseCases.Getplans;

public class GetPlansUseCase
{
    public async Task<Result<GetPlansResponse>> Do(GetPlansPayload payload)
    {
        return Result<GetPlansResponse>.Success(null);
    }
    
}