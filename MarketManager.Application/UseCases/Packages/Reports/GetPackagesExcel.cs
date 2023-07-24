using AutoMapper;
using ClosedXML.Excel;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Application.UseCases.Packages.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MarketManager.Application.UseCases.Packages.Reports
{
    public class GetPackagesExcel:IRequest<ExcelReportResponse>
    {
        public string FileName { get; set; }
    }

    public class GetPackagesExcelHandler : IRequestHandler<GetPackagesExcel, ExcelReportResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPackagesExcelHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExcelReportResponse> Handle(GetPackagesExcel request, CancellationToken cancellationToken)
        {
            using (XLWorkbook workbook= new())
            {
                var orderData = await GetPackagesAsync(cancellationToken);
                var excelSheet = workbook.AddWorksheet(orderData, "Packages");

                excelSheet.RowHeight = 20;
                excelSheet.Column(1).Width = 35;
                excelSheet.Column(2).Width = 35;
                excelSheet.Column(3).Width = 15;
                excelSheet.Column(4).Width = 15;
                excelSheet.Column(5).Width = 35;
                excelSheet.Column(6).Width = 15;
                excelSheet.Column(7).Width = 15;
                excelSheet.Column(8).Width = 15;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);

                    return new ExcelReportResponse(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{request.FileName}.xlsx");
                }
            }
        }

        private async Task<DataTable> GetPackagesAsync(CancellationToken cancellationToken = default)
        {
            var AllPackages = await _context.Packages.ToListAsync(cancellationToken);

            DataTable excelDataTable = new()
            {
                TableName = "Empdata"
            };

            excelDataTable.Columns.Add("Id", typeof(Guid));
            excelDataTable.Columns.Add("ProductId", typeof(Guid));
            excelDataTable.Columns.Add("IncomingCount", typeof(decimal));
            excelDataTable.Columns.Add("Count", typeof(decimal));
            excelDataTable.Columns.Add("SupplierId", typeof(Guid));
            excelDataTable.Columns.Add("IncomingPrice", typeof(decimal));
            excelDataTable.Columns.Add("SalePrice", typeof(decimal));
            excelDataTable.Columns.Add("IncomingDate", typeof(DateTime));



            var packagesList = _mapper.Map<List<PackageResponse>>(AllPackages);

            if (packagesList.Count > 0)
            {
                packagesList.ForEach(item =>
                {
                    excelDataTable.Rows.Add(item.Id, item.ProductId, item.IncomingCount, item.Count, item.SupplierId, item.IncomingPrice, item.SalePrice, item.IncomingDate);

                });
            }

            return excelDataTable;
        }
    }
}
