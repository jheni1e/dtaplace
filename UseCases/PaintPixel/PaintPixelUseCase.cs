using dtaplace.Models;

namespace dtaplace.UseCases.PaintPixel;

public class PaintPixelUseCase(DTAPlaceDbContext ctx)
{
    public async Task<Result<PaintPixelResponse>> Do(PaintPixelPayload payload)
    {
        //Um Dono, Administrador ou Pintor pode escolher pintar um pixel com uma posição (x, y) com uma cor qualquer RGB.
        // Mas cada usuário só pode pintar um pixel a cada 60 segundos.
        // Usuário Gold podem pintar a cada 50 segundos e usuários Platinum a cada 40 segundos.
        return Result<PaintPixelResponse>.Success(null);
    }
}