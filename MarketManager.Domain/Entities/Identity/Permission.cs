using MarketManager.Domain.Entities.Identity;
using System.Runtime.CompilerServices;

namespace MarketManager.Domain.Entities;

public class Permission : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }
}
