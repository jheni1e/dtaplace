using dtaplace.Models;
using dtaplace.Services.Profiles;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.UseCases.GetInvitations;

public class GetInvitationsUseCase (IProfileService profileService)
{
    public async Task<Result<GetInvitationsResponse>> Do(GetInvitationsPayload payload)
    {
        var profile = await profileService.GetProfile(payload.Username);

        if (profile is null)
            return Result<GetInvitationsResponse>.Fail("Usuário não encontrado!");

        var invitations = profile.Invitations;

        if (invitations is null)
            return Result<GetInvitationsResponse>.Fail("Convites não encontrados!");

        return Result<GetInvitationsResponse>.Success(new GetInvitationsResponse(invitations));
    }
}