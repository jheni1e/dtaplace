namespace dtaplace.UseCases.SetRoles;

public record SetRolesPayload (
    int RequesterID,
    int UserID,
    int RoomID,
    int RoleID
);