using Microsoft.AspNetCore.Mvc;

namespace dtaplace.Endpoints;

public static class InvitationsEndpoints
{
    public static void ConfigureInvitationsEndpoints(this WebApplication app)
    {
        app.MapGet("invitations", ([FromServices] GetInvitationsUseCase useCase) =>
        {
            var result = await useCase.Do();
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

        app.MapGet("invitations/{invitationID}/accept", (
            int invitationID,
            [FromServices] AcceptInvitationsUseCase useCase) =>
        {
            var result = await useCase.Do();
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });
    }
}