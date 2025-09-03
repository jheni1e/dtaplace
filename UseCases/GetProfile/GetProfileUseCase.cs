using dtaplace.Models;
using dtaplace.Services.Profiles;

namespace dtaplace.UseCases.GetProfile;

public class GetProfileUseCase
(
    IProfileService profileService,
    DTAPlaceDbContext ctx
)
{
    public async Task<Result<GetProfileResponse>> Do(GetProfilePayload payload)
    {
        var profile = await profileService.GetProfile(payload.Username);
        if (profile is null)
            return Result<GetProfileResponse>.Fail("User doesn't exist.");

        var plan = ctx.Plans.SingleOrDefault(p => p.ID == profile.PlanID);
        if (plan is null)
            return Result<GetProfileResponse>.Fail("Plan not found");

        var response = new GetProfileResponse(
            profile.Username,
            profile.Bio,
            profile.ImageURL,
            plan.Name
        );

        return Result<GetProfileResponse>.Success(response);
        //Retorna todos os dados exceto email e senha, incluso o plano
    }
}