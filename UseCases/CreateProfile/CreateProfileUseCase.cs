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
        var username = profileService.GetProfile(payload.Username);
        var email = profileService.GetProfile(payload.Email);
        if (username is not null || email is not null)
            return Result<CreateProfileResponse>.Fail("Username or email already in use.");

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