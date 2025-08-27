namespace dtaplace.UseCases.AcceptInvitation;

public record AcceptInvitationPayload (
    string UserID,
    string RequestID
);