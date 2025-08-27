namespace dtaplace.UseCases.SendInvitation;

public record SendInvitationPayload (
    int ReceiverID,
    int RoomID
);