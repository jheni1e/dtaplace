using dtaplace.UseCases.Getplans;
using Microsoft.AspNetCore.Mvc;
using dtaplace.Services.Profiles;
namespace dtaplace.Endpoints;

using System.Security.Claims;
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
        }).RequireAuthorization();

        app.MapPost("create/profile", async (
            [FromBody] CreateProfilePayload payload,
            [FromServices] CreateProfileUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();
            return Results.BadRequest(result.Reason);
        });

        app.MapPost("paint", async (
            HttpContext http,
            [FromBody] PaintPixelPayload payload,
            [FromServices] PaintPixelUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return Results.Unauthorized();

            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();
            return Results.BadRequest();

        }).RequireAuthorization();

        app.MapPut("edit/profile", async (
            HttpContext http,
            [FromBody] EditProfilePayload payload,
            [FromServices] EditProfileUseCase useCase) =>

        {
            //Autenticação do usuário
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return Results.Unauthorized();
            
            //Chama o useCase
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();
            return Results.BadRequest();

        }).RequireAuthorization();

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