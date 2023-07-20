using AutoMapper;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.Mappings
{
    public class PermissionMapping:Profile
    {
        public PermissionMapping()
        {
            CreateMap<Permission, PermissionResponse>()
                .ForMember(x=>x.PermissionId, o=>o.MapFrom(x=>x.Id))
                .ForMember(x => x.PermissionName, o => o.MapFrom(x => x.Name));
        }
    }
}
