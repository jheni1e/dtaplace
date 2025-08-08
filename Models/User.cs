namespace dtaplace.Models;

public class User
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Bio { get; set; }
    public string ImageURL { get; set; }
    public int PlanID { get; set; }
    public DateTime Expiration { get; set; }
    public Plan Plan { get; set; }
    public ICollection<Room> Rooms { get; set; } = [];
    public ICollection<Invitation> Invitations { get; set; } = [];
    public ICollection<UserRoom> UserRooms { get; set; } = [];
}