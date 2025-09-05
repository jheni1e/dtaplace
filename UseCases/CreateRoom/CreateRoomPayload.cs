using System.ComponentModel.DataAnnotations;
using dtaplace.Models;

namespace dtaplace.UseCases.CreateRoom;

public record CreateRoomPayload
{
    [Required]
    public string Name { get; set; }

    [Required]
    public int Width { get; set; }

    [Required]
    public int Height { get; set; }
    [Required]
    public string CreatorUsername { get; set; }
}