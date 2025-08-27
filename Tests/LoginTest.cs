using Xunit;
using dtaplace.Services.Password;
using Moq;
using dtaplace.Services.Profiles;
using dtaplace.Services.JWT;

namespace dtaplace.Tests;

public class AuthTest
{
    [Theory]
    [InlineData("minhasenhaA", "minhasenhaA", true)]
    [InlineData("12345678", "sdfjkadsjh", false)]
    [InlineData("", "a", false)]
    [InlineData("acomplexpassword314", "acomplexpassword314", true)]
    public void TestPassword(string senha1, string senha2, bool result)
    {
        var hasher = new PBKDF2Service();

        var hash = hasher.Hash(senha1);
        var ok = hasher.Compare(senha2, hash);
        Assert.Equal(result, ok);
    }

    [Fact]
    public async Task TestProfile()
    {
        var profileService = new Mock<IProfileService>();

        var user = await profileService.GetProfile(payload.Login);
        if (user is null)
            return Result<LoginResponse>.Fail("User not found");

        var passwordService = new Mock<IPasswordService>();
        passwordService.Setup(s => s.Compare(payload.Password, user.Password)))
            .Returns(true);

        var jwtService = new Mock<IJWTService>();

        var useCase = new LoginUseCase(
            profileService.Object,
            passwordService.Object,
            jwtService.Object
        );

        var result = await useCase.Do(new LoginPayload("trevis", "cristians2"));
        Assert.True(result.IsSuccess);
    }
}