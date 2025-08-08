namespace dtaplace.Models;

public class GiftCard
{
    public int ID { get; set; }
    public string Code { get; set; }
    public int PlanID { get; set; }
    public int Duration { get; set; } // por default, a duração é em meses

    public Plan Plan { get; set; }
}