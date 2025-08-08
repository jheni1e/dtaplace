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

        app.MapPost("create/role", (
            [FromBody] CreateRolePayload payload,
            [FromServices] CreateRoleUseCase useCase) =>
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
    }
}