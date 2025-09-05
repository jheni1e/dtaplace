namespace dtaplace.UseCases.SendInvitation;

public record SendInvitationPayload (
    string ReceiverName,
    int SenderID,
    int RoomID
);