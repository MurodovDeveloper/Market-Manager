﻿using AutoMapper;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Users.Commands.CreateUser;
using MarketManager.Application.UseCases.Users.Commands.RegisterUser;
using MarketManager.Application.UseCases.Users.Response;
using MarketManager.Domain.Entities.Identity;

namespace MarketManager.Application.Common.Mappings;
public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<UserResponse, User>().ReverseMap();
        CreateMap<RegisterUserCommand, User>().ReverseMap();
        CreateMap<CreateUserCommand, User>().ReverseMap();
        CreateMap<UsersResponseExcelReport, User>().ReverseMap();
            //     .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles))
            //.ReverseMap();    
    }
}
