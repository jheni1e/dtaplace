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
            [FromBody] GetInvitationsPayload payload,
            [FromServices] GetInvitationsUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapPost("invite/{payload.Username}", async (
            [FromBody] SendInvitationPayload payload,
            [FromServices] SendInvitationUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });

        app.MapGet("invitations/{payload.UserID}/accept", async (
            [FromBody] AcceptInvitationPayload payload,
            [FromServices] AcceptInvitationUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });
    }
}