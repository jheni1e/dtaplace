namespace dtaplace.UseCases.DeleteRoomUser;

public record DeleteRoomUserPayload (
    int UserID,
    int RoomID
);