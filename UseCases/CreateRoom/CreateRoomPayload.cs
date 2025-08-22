using System.ComponentModel.DataAnnotations;

namespace dtaplace.UseCases.CreateRoom;

public record CreateRoomPayload
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int Width { get; set; }

    [Required]
    public int Height { get; set; }
}