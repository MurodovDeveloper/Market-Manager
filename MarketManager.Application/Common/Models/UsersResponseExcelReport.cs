using AutoMapper;
using MarketManager.Application.UseCases.Roles.Response;
using MarketManager.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common.Models;
public class UsersResponseExcelReport
{
    
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public List<RoleResponse> Roles { get; set; }
}
