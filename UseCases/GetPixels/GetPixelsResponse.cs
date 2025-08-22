using dtaplace.Models;

namespace dtaplace.UseCases.GetPixels;

public record GetPixelsResponse (
    List<Pixel> Pixels
);