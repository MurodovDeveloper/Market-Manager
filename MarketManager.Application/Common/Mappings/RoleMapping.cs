using AutoMapper;
using MarketManager.Application.UseCases.Roles.Queries;
using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Application.Common.Mappings;
public class RoleMapping : Profile
{
    public RoleMapping()
    {
      //  CreateMap<GetAllRolesQueryResponse, Role>().ReverseMap();
    }
}
