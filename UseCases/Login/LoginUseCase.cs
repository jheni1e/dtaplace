namespace dtaplace.UseCases.Login;

public class LoginUseCase(
    IProfilesService profilesService,
    IPasswordService passwordService,
    IJWTService jWTService
)
{
    public async Task<Result<LoginResponse>> Do(LoginPayload payload)
    {
        var user = await profilesService.FindByLogin(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");

        var passwordMatch = passwordService
            .Compare(payload.Password, user.Password);

        if (!passwordMatch)
            return Result<LoginResponse>.Fail("User not found");

        var jwt = jWTService.CreateToken(
            new (
            user.ID,
            user.Username
        ));
        
        return Result<LoginResponse>.Success(new LoginResponse(jwt));
    }
}