namespace dtaplace.UseCases.SendInvitation;

public class SendInvitationUseCase
{
    public async Task<Result<SendInvitationResponse>> Do(SendInvitationPayload payload)
    {
        return Result<SendInvitationResponse>.Success(null);
    }
}