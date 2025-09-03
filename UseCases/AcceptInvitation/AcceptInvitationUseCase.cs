namespace dtaplace.UseCases.AcceptInvitation;

public class AcceptInvitationUseCase
{
    public async Task<Result<AcceptInvitationResponse>> Do(AcceptInvitationPayload payload)
    {
        return Result<AcceptInvitationResponse>.Success(null);
        //Usuários logados podem ver, aceitar ou rejeitar convites para participar de uma sala de desenho.
    }
}