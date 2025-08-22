namespace dtaplace.UseCases.GetRoles;
public class GetRolesUseCase
{
    public async Task<Result<GetRolesResponse>> Do(GetRolesPayload payload)
    {
        return Result<GetRolesResponse>.Success(null);
    }
}