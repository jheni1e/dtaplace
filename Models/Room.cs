namespace dtaplace.Models;

public class Room
{
    public int ID { get; set; }
    public string Name { get; set; }

    public ICollection<Pixel> Pixels { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
}