using MarketManager.Domain.Entities.Identity;
using System.Text.Json.Serialization;

namespace MarketManager.Domain.Entities;

public class Permission : BaseAuditableEntity
{
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Role>? Roles { get; set; }
}
