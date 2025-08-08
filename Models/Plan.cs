namespace dtaplace.Models;

public class Plan
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; } = [];
    public ICollection<GiftCard> GiftCards { get; set; } = [];
}