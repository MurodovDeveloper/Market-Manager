using MarketManager.Application.Common;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Permissions.ResponseModels;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
