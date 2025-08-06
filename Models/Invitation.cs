namespace dtaplace;

public class Invitation
{
    public int ID { get; set; }
    public string Description { get; set; }

    User Receiver { get; set; }
    Room Room { get; set; }
}