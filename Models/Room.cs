namespace dtaplace.Models;

public class Room
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public int CreatorID { get; set; }
    public int PixelID { get; set; }

    User Creator { get; set; }
    ICollection<Pixel> Pixels { get; set; } = [];

}