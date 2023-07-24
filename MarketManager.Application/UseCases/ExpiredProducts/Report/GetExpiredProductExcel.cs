using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common;
using MarketManager.Domain.Entities;
using MediatR;
using MarketManager.Application.Common.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.UseCases.ExpiredProducts.Report
{
    public class GetExpiredProductExcel : IRequest<Users.Report.ExcelReportResponse>
    {
        public string FileName { get; set; }
    }
    public class GetExpiredProductExcelHandler : IRequestHandler<GetExpiredProductExcel, Users.Report.ExcelReportResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly GenericExcelReport _generic;
        public GetExpiredProductExcelHandler(IApplicationDbContext context, GenericExcelReport generic)
        {
            _context = context;
            _generic = generic;
        }

        public async Task<Users.Report.ExcelReportResponse> Handle(GetExpiredProductExcel request, CancellationToken cancellationToken)
        {

            Users.Report.ExcelReportResponse result = await _generic.GetReportExcel<ExpiredProduct, ExpiredProductBaseResponce>(request.FileName, await _context.ExpiredProducts.ToListAsync(cancellationToken), cancellationToken);
            return result;
        }
    }
}
