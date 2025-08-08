using Microsoft.AspNetCore.Mvc;

namespace dtaplace.Endpoints;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapGet("profile/{username}", async (
            string username,
            [FromServices] GetUserUseCase useCase) =>
        {
            var payload = new GetUserPayload(username);
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(result.Data)
            };
        });

        app.MapPost("profile/create", async (
            [FromBody] CreateUserPayload payload,
            [FromServices] CreateUserUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapPut("profile/edit", async (
            [FromBody] EditUserPayload payload,
            [FromServices] EditUserUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapGet("plans", async ([FromServices] GetPlansUseCase useCase) =>
        {
            var result = await useCase.Do();

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(result.Data)
            };
        });

        app.MapPost("subscribe/{payload.Name}", async (
            [FromBody] SubscribePlanPayload payload,
            [FromServices] SubscribePlanUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });
    }
}