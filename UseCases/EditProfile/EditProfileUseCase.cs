using dtaplace.Models;
using dtaplace.Services.Profiles;
namespace dtaplace.UseCases.EditProfile;

public class EditProfileUseCase
(
    IProfileService profileService,
    DTAPlaceDbContext ctx
)
{
    public async Task<Result<EditProfileResponse>> Do(EditProfilePayload payload)
    {
        var user = await profileService.GetProfile(payload.Login);
        if (user is null)
            return Result<EditProfileResponse>.Fail("User not found.");

        if (payload.Password != user.Password)
                return Result<EditProfileResponse>.Fail("Senha incorreta.");

        // if (payload.Bio is not null)
        //     user.Bio = payload.Bio;
        // a mesma coisa que o código abaixo

        user.Bio = payload.Bio ?? user.Bio;
        user.Email = payload.Email ?? user.Email;
        user.ImageURL = payload.ImageURL ?? user.ImageURL;
        user.Username = payload.Username ?? user.Username;

        await ctx.SaveChangesAsync();
        
        return Result<EditProfileResponse>.Success(null);
    }
}