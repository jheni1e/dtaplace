using dtaplace.Services.JWT;
using dtaplace.Services.Password;
using dtaplace.Services.Profiles;

namespace dtaplace.UseCases.Login;

public class LoginUseCase(
    IProfileService profilesService,
    IPasswordService passwordService,
    IJWTService jWTService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profilesService.GetProfile(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");

        var passwordMatch = passwordService
            .Compare(payload.Password, user.Password);

        if (!passwordMatch)
            return Result<LoginResponse>.Fail("User not found");

        var jwt = jWTService.CreateToken(
            new (
            user.ID,
            user.Username,
            user.PlanID,
            user.Expiration
        ));
        
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}