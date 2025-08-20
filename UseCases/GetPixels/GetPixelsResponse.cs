using dtaplace.Models;

namespace dtaplace.UseCases.GetPixels;

public record GetPixelsResponse (
    ICollection<Pixel> Pixels
);