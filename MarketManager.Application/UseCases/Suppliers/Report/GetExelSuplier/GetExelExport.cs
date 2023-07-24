using ClosedXML.Excel;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MarketManager.Application.UseCases.Suppliers.Report.GetExelSuplier;

public record GetExelExport(string FileName) : IRequest<ExcelReportResponse>;
public class GetExelExportHandler : IRequestHandler<GetExelExport, ExcelReportResponse>
{
    private readonly IApplicationDbContext _context;
    public GetExelExportHandler(IApplicationDbContext context) => _context = context;
    public async Task<ExcelReportResponse> Handle(GetExelExport request, CancellationToken cancellationToken)
    {
        var suppliers = await _context.Suppliers.ToListAsync(cancellationToken);
        if (suppliers is null || suppliers.Count <= 0) throw new NotFoundException(nameof(Supplier), "suppliers");
        DataTable dt = new DataTable()
        {
            TableName = request.FileName
        };
        dt.Columns.Add("Id", typeof(Guid));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Phone", typeof(string));
        foreach (var supplier in suppliers)
        {
            DataRow rowId = dt.NewRow();
            rowId["Id"] = supplier.Id;
            dt.Rows.Add(rowId);

            DataRow rowName = dt.NewRow();
            rowName["Name"] = supplier.Name;
            dt.Rows.Add(rowName);

            DataRow rowPhone = dt.NewRow();
            rowPhone["Phone"] = supplier.Name;
            dt.Rows.Add(rowPhone);
        }
        using XLWorkbook wb = new XLWorkbook();
        wb.Worksheets.Add(dt, "shit2");
        using MemoryStream ms = new MemoryStream();
        wb.SaveAs(ms);
        return new ExcelReportResponse(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "test.xlsx");
    }
}
