﻿namespace MarketManager.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ProductImage { get; set; }
    public Guid ProductTypeId { get; set; }
    public virtual ProductType ProductType { get; set; }

    public virtual ICollection<Package> Packages { get; set; }

}
