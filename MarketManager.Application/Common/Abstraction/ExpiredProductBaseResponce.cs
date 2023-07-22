namespace MarketManager.Application.Common.Abstraction
{
    public abstract class ExpiredProductBaseResponce
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public int Count { get; set; }
        public DateTime DeletedTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public Guid CreatedById { get; set; }
        public Guid ModifyById { get; set; }
    }
}
