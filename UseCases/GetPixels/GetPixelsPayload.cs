using System.ComponentModel.DataAnnotations;
namespace dtaplace.UseCases.GetPixels;

public class GetPixelsPayload
{
    [Required]
    public int PositionX { get; set; }
    [Required]
    public int PositionY { get; set; }

    [Required]
    public string R { get; set; }
    [Required]
    public string G { get; set; }
    [Required]
    public string B { get; set; }
}