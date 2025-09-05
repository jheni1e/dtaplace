using System.Security.Claims;
using dtaplace.UseCases.AcceptInvitation;
using dtaplace.UseCases.GetInvitations;
using dtaplace.UseCases.SendInvitation;
using Microsoft.AspNetCore.Mvc;

namespace dtaplace.Endpoints;

public static class InvitationsEndpoints
{
    public static void ConfigureInvitationsEndpoints(this WebApplication app)
    {
        app.MapGet("invitations", async (
            HttpContext http,
            [FromBody] GetInvitationsPayload payload,
            [FromServices] GetInvitationsUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.Name);
            if (claim is null)
                return Results.Unauthorized();
            
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();
        }).RequireAuthorization();

        app.MapPost("invite/{payload.Username}", async (
            HttpContext http,
            [FromBody] SendInvitationPayload payload,
            [FromServices] SendInvitationUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return Results.Unauthorized();

            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();
        }).RequireAuthorization();

        app.MapGet("invitations/{payload.UserID}/accept", async (
            HttpContext http,
            [FromBody] AcceptInvitationPayload payload,
            [FromServices] AcceptInvitationUseCase useCase) =>
        {
            var claim = http.User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim is null)
                return Results.Unauthorized();

            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Reason);

            return Results.Ok();
        }).RequireAuthorization();
    }
}