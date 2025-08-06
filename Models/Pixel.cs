using System.Drawing;

namespace dtaplace.Models;

public class Pixel
{
    public int ID { get; set; }

    public int R { get; set; }
    public int G { get; set; }  
    public int B { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
    
    public int RoomID { get; set; }

    public Room Room { get; set; }
}