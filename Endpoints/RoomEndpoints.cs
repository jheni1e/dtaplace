using Microsoft.AspNetCore.Mvc;

namespace dtaplace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapGet("rooms", ([FromServices] GetRoomsUseCase useCase) =>
        {
            var result = await useCase.Do();
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapPost("create/room", (
            [FromBody] CreateRoomPayload payload,
            [FromServices] CreateRoomUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapGet("roles", ([FromServices] GetRolesUseCase useCase) =>
        {
            var result = await useCase.Do();
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapPost("set/role", (
            [FromBody] SetRolePayload payload,
            [FromServices] SetRoleUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapPost("invite/{username}", (
            string username,
            [FromServices] SendInvitationUseCase useCase) =>
        {
            var payload = new SendInvitationPayload(username);
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapDelete("delete/{username}", (
            string username,
            [FromServices] DeleteRoomUser useCase) =>
        {
            var result = await useCase.Do(username);
            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(result.Data)
            };
        });

        app.MapGet("canvas", (
            [FromServices] GetPixelsUseCase useCase) =>
        {
            var result = await useCase.Do();
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });
    }
}