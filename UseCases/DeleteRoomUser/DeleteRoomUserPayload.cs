namespace dtaplace.UseCases.DeleteRoomUser;

public record DeleteRoomUserPayload(
    int roomID,
    int UserID
);