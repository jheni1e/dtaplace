namespace dtaplace.UseCases.SetRoles;

public record SetRolesPayload(
    int UserID,
    int RoomID,
    string Rolename
);