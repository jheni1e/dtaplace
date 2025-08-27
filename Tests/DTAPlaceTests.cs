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

//     [Fact]
//     public async Task TestCreateRoom()
//     {
//         var roomService = new Mock<IRoomService>();
//         roomService.Setup(s => s.CreateRoom(It.IsAny<Room>()))
//             .ReturnsAsync(100);

//         var useCase = new CreateRoomUseCase(roomService.Object);

//         var result = await useCase.Do(new CreateRoomPayload (
//             // Name: "Sala Teste",
//             // Width: 50,
//             // Height: 50
//         ));

//         Assert.Equal(100, result);
//     }

//     [Fact]
//     public async Task TestGetRoom()
//     {
//         var roomService = new Mock<IRoomService>();
//         roomService.Setup(s => s.GetRoom(42))
//             .ReturnsAsync(new Room { ID = 42, Name = "Sala Teste" });

//         var useCase = new GetRoomsUseCase(roomService.Object);

//         var result = await useCase.Do(new GetRoomsPayload(42));

//         Assert.NotNull(result);
//         Assert.Equal("Sala Teste", result!.Name);
//     }
// }