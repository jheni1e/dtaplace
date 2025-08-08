namespace dtaplace.Models;

public class Invitation
{
    public int ID { get; set; }
    public int ReceiverID { get; set; }
    public int RoomID { get; set; }
    
    public User Receiver { get; set; }
    public Room Room { get; set; }
}