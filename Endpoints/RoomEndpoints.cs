using dtaplace.UseCases.CreateRoom;
using dtaplace.UseCases.DeleteRoomUser;
using dtaplace.UseCases.GetPixels;
using dtaplace.UseCases.GetRoles;
using dtaplace.UseCases.GetRooms;
using dtaplace.UseCases.SetRoles;
using Microsoft.AspNetCore.Mvc;

namespace dtaplace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapGet("rooms", async (
            [FromBody] GetRoomsPayload payload,
            [FromServices] GetRoomsUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapPost("create/room", async (
            [FromBody] CreateRoomPayload payload,
            [FromServices] CreateRoomUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapGet("roles", async(
            
            [FromServices] GetRolesUseCase useCase) =>
        {
            var result = await useCase.Do(null);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        _ = app.MapPost("set/role", async (
            [FromBody] SetRolesPayload payload,
            [FromServices] SetRolesUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        _ = app.MapDelete("delete/{payload.UserID}", async (
            [FromBody]DeleteRoomUserPayload payload,
            [FromServices] DeleteRoomUserUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(result.Data)
            };
        });

        app.MapGet("canvas", async (
            [FromBody] GetPixelsPayload payload,
            [FromServices] GetPixelsUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });
    }
}