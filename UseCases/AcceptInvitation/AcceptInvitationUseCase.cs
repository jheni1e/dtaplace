namespace dtaplace.UseCases.AcceptInvitation;

public class AcceptInvitationUseCase
{
    public async Task<Result<AcceptInvitationResponse>> Do(AcceptiInvitationPayload payload)
    {
        //podem editar tudo, menos a senha, para poder editar precisa passar a senha
        return Result<AcceptInvitationResponse>.Success(null);
    }
}