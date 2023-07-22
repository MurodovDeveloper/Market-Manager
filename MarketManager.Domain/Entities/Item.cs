using System.ComponentModel.DataAnnotations.Schema;

namespace MarketManager.Domain.Entities;

public class Item : BaseAuditableEntity
{
    public double Count { get; set; }
    public double SoldPrice { get; set; }

    public Guid PackageId { get; set; }
    public Guid OrderId { get; set; }


    public virtual Package Package { get; set; }

    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; }
}
