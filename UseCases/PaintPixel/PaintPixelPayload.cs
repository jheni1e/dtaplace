namespace dtaplace.UseCases.PaintPixel;

public record PaintPixelPayload(
    int R,
    int G,
    int B,
    int X,
    int Y,
    int RoomID,
    string Username
);
