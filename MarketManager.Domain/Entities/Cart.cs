using System.ComponentModel.DataAnnotations.Schema;

namespace MarketManager.Domain.Entities;

public class Cart : BaseAuditableEntity
{
    public double Count { get; set; }
    public double SoldPrice { get; set; }

    public Guid PackageId { get; set; }
    public virtual Package Package { get; set; }

    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
}
