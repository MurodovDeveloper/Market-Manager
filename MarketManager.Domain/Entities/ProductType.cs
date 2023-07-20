namespace MarketManager.Domain.Entities;

public class ProductType : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
