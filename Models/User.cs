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
    
    Plan Plan { get; set; }
}