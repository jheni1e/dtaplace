namespace dtaplace.Models;

public class Invitation
{
    public int ID { get; set; }
    public string Description { get; set; }
    public int ReceiverID { get; set; }
    public int RoomID { get; set; }
    User Receiver { get; set; }
    Room Room { get; set; }
}