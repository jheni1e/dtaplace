namespace dtaplace.Models;

public class GiftCard
{
    public int ID { get; set; }
    public string Code { get; set; }
    public int PlanID { get; set; }
    public int Duration { get; set; }

    Plan Plan { get; set; }
}