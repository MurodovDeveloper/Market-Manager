using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Permissions.ResponseModels
{
    public class PermissionGetDto
    {
        public Guid PermissionId { get; set; }
        public string PermissionName { get; set; }
    }
}
