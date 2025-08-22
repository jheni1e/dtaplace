namespace dtaplace.Models;

public class UserRoom
{
    public int ID { get; set; }
    public int RoomID { get; set; }
    public int UserID { get; set; }
    public int RoleID { get; set; }
    
    public User User { get; set; }
    public Room Room { get; set; }
    public Role Role { get; set; }
}