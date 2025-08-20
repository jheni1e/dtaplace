namespace dtaplace.UseCases.CreateProfile;

public class CreateProfileUseCase(
    IProfileService profileService,
    IPasswordService passwordService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
         return Result<CreateProfileResponse>.Success(null);
    }
}