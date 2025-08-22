using System.ComponentModel.DataAnnotations;
using dtaplace.Models;
using dtaplace.Services.Profiles;
using Microsoft.EntityFrameworkCore;
namespace dtaplace.UseCases.EditProfile;

public class EditProfileUseCase (
    IProfileService profileService
)
{
    public async Task<Result<EditProfileResponse>> Do(EditProfilePayload payload)
    {
        var user = await profileService.GetProfile(payload.OldUsername);

        if (payload.Password != user.Password)
            return Result<EditProfileResponse>.Fail("Senha incorreta.");

        if (payload.Bio is not null)
            user.Bio = payload.Bio;
        if (payload.Email is not null)
            user.Email = payload.Email;
        if (payload.ImageURL is not null)
            user.ImageURL = payload.ImageURL;
        if (payload.Username is not null)
            user.Username = payload.Username;

        return Result<EditProfileResponse>.Success(null);
    }
}