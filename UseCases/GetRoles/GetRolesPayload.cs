namespace dtaplace.UseCases.GetRoles;
public record GetRolesPayload(
    int RoomID,
    int UserID
);