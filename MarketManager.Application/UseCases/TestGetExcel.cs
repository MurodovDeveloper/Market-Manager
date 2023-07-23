using MarketManager.Application.Common;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Application.UseCases.Users.Report;
using MarketManager.Application.UseCases.Users.Response;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases;
public class TestGetExcel : IRequest<ExcelReportResponse>
{
    public string FileName { get; set; }
}
public class TestGetExcelProductHandler : IRequestHandler<TestGetExcel, ExcelReportResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly GenericExcelReport _generic;
    public TestGetExcelProductHandler(IApplicationDbContext context, GenericExcelReport generic)
    {
        _context = context;
        _generic = generic;
    }

    public async Task<ExcelReportResponse> Handle(TestGetExcel request, CancellationToken cancellationToken)
    {

        var result = await _generic.GetReportExcel<Permission, PermissionResponse>(request.FileName, await _context.Permissions.ToListAsync(cancellationToken), cancellationToken);
        return result;
    }
}
