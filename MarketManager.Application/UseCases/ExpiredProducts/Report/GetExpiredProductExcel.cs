using MarketManager.Application.Common;
using MarketManager.Application.Common.Abstraction;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.ExpiredProducts.Report
{
    public class GetExpiredProductExcel : IRequest<ExcelReportResponse>
    {
        public string FileName { get; set; }
    }
    public class GetExpiredProductExcelHandler : IRequestHandler<GetExpiredProductExcel, ExcelReportResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly GenericExcelReport _generic;
        public GetExpiredProductExcelHandler(IApplicationDbContext context, GenericExcelReport generic)
        {
            _context = context;
            _generic = generic;
        }

        public async Task<ExcelReportResponse> Handle(GetExpiredProductExcel request, CancellationToken cancellationToken)
        {

            var result = await _generic.GetReportExcel<ExpiredProduct, ExpiredProductBaseResponce>(request.FileName, await _context.ExpiredProducts.ToListAsync(cancellationToken), cancellationToken);
            return result;
        }
    }
}
