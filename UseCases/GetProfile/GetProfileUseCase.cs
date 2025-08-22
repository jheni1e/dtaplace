namespace dtaplace.UseCases.GetProfile;

public class GetProfileUseCase
{
    public async Task<Result<GetProfileResponse>> Do (GetProfilePayload payload)
    {
        //retorna todos os dados exceto email e senha, incluso o plano
        return Result<GetProfileResponse>.Success(null);
    }

}