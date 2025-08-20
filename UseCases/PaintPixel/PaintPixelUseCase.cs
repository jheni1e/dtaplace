namespace dtaplace.UseCases.PaintPixel;

public class PaintPixelUseCase
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        return Result<PaintPixelResponse>.Success(null);
    }
}