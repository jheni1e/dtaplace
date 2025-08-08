namespace dtaplace.Endpoints;

public static class RoomEndpoints
{
    public static void ConfigureRoomEndpoints(this WebApplication app)
    {
        app.MapGet("rooms", ([FromServices]GetRoomsUseCase) =>
        {
            var result = await useCase.Do(payload);
            if (result.IsSuccess)
                return Results.Ok();

            return Results.BadRequest(result.Reason);
        });
    }
}