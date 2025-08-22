using dtaplace.Models;
using dtaplace.Services.Profiles;

namespace dtaplace.UseCases.GetProfile;

public class GetProfileUseCase (
    IProfileService profileService
)
{
    public async Task<Result<GetProfileResponse>> Do(GetProfilePayload payload)
    {
        var profile = await profileService.GetProfile(payload.Username);

        if (profile == null)
            return Result<GetProfileResponse>.Fail("Usuario não existe");
        
        var response = new GetProfileResponse(
            profile.Username,
            profile.Bio,
            profile.ImageURL,
            profile.PlanID
        );
        
        //retorna todos os dados exceto email e senha, incluso o plano
        return Result<GetProfileResponse>.Success(response);
    }

}