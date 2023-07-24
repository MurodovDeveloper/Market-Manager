namespace MarketManager.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public decimal TotalPrice { get; set; }
    public Guid ClientId { get; set; }
    public decimal ItemPriceSum { get; set; }
    public decimal ItemPurchaseSum { get; set; }

    public virtual ICollection<Item>? Items { get; set; }

    public virtual Client Client { get; set; }
}
