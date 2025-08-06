using System.Drawing;

namespace dtaplace.Models;

public class Pixel
{
    public int ID { get; set; }
    public Color Color { get; set; }
    public int RoomID { get; set; }
    Room Room { get; set; }
}