using dtaplace.UseCases.Getplans;
using Microsoft.AspNetCore.Mvc;
using dtaplace.Services.Profiles;
namespace dtaplace.Endpoints;

using dtaplace.Models;
using dtaplace.UseCases.CreateProfile;
using dtaplace.UseCases.EditProfile;
using dtaplace.UseCases.GetProfile;
using dtaplace.UseCases.PaintPixel;

public static class UserEndpoints
{
    public static void ConfigureUserEndpoints(this WebApplication app)
    {
        app.MapGet("profile/{username}", async (
            string username,
            [FromServices] GetProfileUseCase useCase) =>
        {
            var payload = new GetProfilePayload(username);
            var result = await useCase.Do(payload);

            return (result.IsSuccess, result.Reason) switch
            {
                (false, "User not found") => Results.NotFound(),
                (false, _) => Results.BadRequest(),
                (true, _) => Results.Ok(result.Data)
            };
        });

        app.MapPost("profile/create", async (
            [FromBody] CreateProfilePayload payload,
            [FromServices] CreateProfileUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapPost("paint", async (
            [FromBody] PaintPixelPayload payload,
            [FromServices] PaintPixelUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();
            return Results.BadRequest();
        });

        app.MapPut("edit", async (
            [FromBody] EditProfilePayload payload,
            [FromServices] EditProfileUseCase useCase) =>

        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();
            return Results.BadRequest();
        }
        );

        // app.MapPost("profile/create", async (
        //     [FromBody] CreateUserPayload payload,
        //     [FromServices] CreateUserUseCase useCase) =>
        // {
        //     var result = await useCase.Do(payload);
        //     if (result.IsSuccess)
        //         return Results.Ok();

        //     return Results.BadRequest(result.Reason);
        // });

        // app.MapPut("profile/edit", async (
        //     [FromBody] EditUserPayload payload,
        //     [FromServices] EditUserUseCase useCase) =>
        // {
        //     var result = await useCase.Do(payload);
        //     if (result.IsSuccess)
        //         return Results.Ok();

        //     return Results.BadRequest(result.Reason);
        // });

        // app.MapGet("plans", async ([FromServices] GetPlansUseCase useCase) =>
        // {
        //     var result = await useCase.Do();

        //     return (result.IsSuccess, result.Reason) switch
        //     {
        //         (false, "User not found") => Results.NotFound(),
        //         (false, _) => Results.BadRequest(),
        //         (true, _) => Results.Ok(result.Data)
        //     };
        // });

        // app.MapPost("subscribe/{payload.Name}", async (
        //     [FromBody] SubscribePlanPayload payload,
        //     [FromServices] SubscribePlanUseCase useCase) =>
        // {
        //     var result = await useCase.Do(payload);
        //     if (result.IsSuccess)
        //         return Results.Ok();

        //     return Results.BadRequest(result.Reason);
        // });

        // app.MapPost("paint", (
        //     [FromBody] PaintPixelPayload payload,
        //     [FromServices] PaintPixelUseCase useCase) =>
        // {
        //     var result = await useCase.Do(payload);
        //     if (result.IsSuccess)
        //         return Results.Ok();

        //     return Results.BadRequest(result.Reason);
        // });
    }
}