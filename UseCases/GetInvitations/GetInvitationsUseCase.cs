namespace dtaplace.UseCases.GetInvitations;

public class GetInvitationsUseCase
{
    public async Task<Result<GetInvitationsResponse>> Do (GetInvitationsPayload payload)
    {
        return Result<GetInvitationsResponse>.Success(null);
    }
}