namespace dtaplace.UseCases.SetRoles;

public class SetRolesUseCase
{
    public async Task<Result<SetRolesResponse>> Do(SetRolesPayload payload)
    {
        return Result<SetRolesResponse>.Success(null);
    }
}