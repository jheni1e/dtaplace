namespace dtaplace.UseCases.DeleteRoomUser;

public record DeleteRoomUserPayload (
    int RequesterID,
    int UserID,
    int DeletedUserID,
    int RoomID
);