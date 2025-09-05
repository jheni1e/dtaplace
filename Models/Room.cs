namespace dtaplace.Models;

public class Room
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public required User Creator { get; set; }
    public int CreatorID { get; set; }

    public ICollection<UserRoom> UserRooms { get; set; } = [];
    public ICollection<Pixel> Pixels { get; set; } = [];
    public ICollection<User> Users { get; set; } = [];
    public ICollection<Invitation> Invitations { get; set; } = [];

}