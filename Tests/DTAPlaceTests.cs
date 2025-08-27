using Xunit;
using dtaplace.Services.Password;
using Moq;
using dtaplace.Services.Profiles;
using dtaplace.Services.JWT;
using dtaplace.UseCases.Login;
using dtaplace.Models;
using dtaplace.UseCases.CreateRoom;
using dtaplace.Services.Rooms;
using dtaplace.UseCases.GetRooms;
using Microsoft.EntityFrameworkCore;

namespace dtaplace.Tests;

public class PasswordProfileTests
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
        profileService.Setup(s => s.GetProfile("lele"))
            .ReturnsAsync(new Models.User
            {
                Username = "lele",
                Password = "hash_da_senha"
            });

        var passwordService = new Mock<IPasswordService>();
        passwordService.Setup(s => s.Compare("jhenies2", "hash_da_senha"))
            .Returns(true);

        var jwtService = new Mock<IJWTService>();

        var useCase = new LoginUseCase(
            profileService.Object,
            passwordService.Object,
            jwtService.Object
        );

        var result = await useCase.Do(new LoginPayload("lele", "jhenies2"));
        Assert.True(result.IsSuccess);
    }
}

public class RoomTests
{
    [Fact]
    public async Task TestCreateRoom()
    {
        var roomService = new Mock<IRoomService>();
        roomService.Setup(s => s.CreateRoom(It.IsAny<Room>()))
            .ReturnsAsync(100);

        var useCase = new CreateRoomUseCase(roomService.Object);

        var payload = new CreateRoomPayload
        {
            Name = "Sala Teste",
            Width = 50,
            Height = 50
        };

        var result = await useCase.Do(payload);

        Assert.True(result.IsSuccess);

        roomService.Verify(s => s.CreateRoom(It.Is<Room>(
            r => r.Name == "Sala Teste" && r.Width == 50 && r.Height == 50
        )), Times.Once);
    }
}