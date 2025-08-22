using dtaplace.Models;
using dtaplace.Services.Password;
using dtaplace.Services.Profiles;

namespace dtaplace.UseCases.CreateProfile;

public class CreateProfileUseCase(
    IProfileService profileService,
    IPasswordService passwordService
)
{
    public async Task<Result<CreateProfileResponse>> Do(CreateProfilePayload payload)
    {
        var user = new User
        {
            Username = payload.Username,
            Email = payload.Email,
            Password = passwordService.Hash(payload.Password),
            Bio = payload.Bio,
            ImageURL = payload.ImageURL
        };

        await profileService.CreateProfile(user);

        return Result<CreateProfileResponse>.Success(new());
    }
}