using dtaplace.Models;

namespace dtaplace.UseCases.PaintPixel;

public class PaintPixelUseCase (DTAPlaceDbContext ctx)
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        return Result<PaintPixelResponse>.Success(null);
    }
}