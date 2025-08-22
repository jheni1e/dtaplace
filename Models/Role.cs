namespace dtaplace.Models;

public class Role
{
    public int ID { get; set; }
    public string Rolename { get; set; }

    public UserRoom UserRoom { get; set; }
}