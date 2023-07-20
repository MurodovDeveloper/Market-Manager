namespace MarketManager.Domain.Entities
{
    public class Cart : BaseAuditableEntity
    {
        public Guid PackageId { get; set; }
        public Guid OrderId { get; set; }
        public double Count { get; set; }
        public double SoldPrice { get; set; }

        public Package Package { get; set; }

        public Order Order { get; set; }
    }
}
