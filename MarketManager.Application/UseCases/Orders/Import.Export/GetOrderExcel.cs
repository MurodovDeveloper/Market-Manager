using System.Data;
using AutoMapper;
using ClosedXML.Excel;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.Application.UseCases.Orders.Import.Export
{
    public class GetOrderExcel : IRequest<ExcelReportResponse>
    {
        public string FileName { get; set; }
    }

    public class GetOrderExcelHandler : IRequestHandler<GetOrderExcel, ExcelReportResponse>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderExcelHandler(IApplicationDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<ExcelReportResponse> Handle(GetOrderExcel request, CancellationToken cancellationToken)
        {
            using (XLWorkbook wb = new())
            {
                var orderData = await GetOrderAsync(cancellationToken);
                var sheet1 = wb.AddWorksheet(orderData, "Orders");


                sheet1.Column(1).Style.Font.FontColor = XLColor.Red;

                sheet1.Columns(2, 4).Style.Font.FontColor = XLColor.Blue;

                sheet1.Row(1).CellsUsed().Style.Fill.BackgroundColor = XLColor.Black;

                sheet1.Row(1).Style.Font.FontColor = XLColor.White;

                sheet1.Row(1).Style.Font.Bold = true;
                sheet1.Row(1).Style.Font.Shadow = true;
                sheet1.Row(1).Style.Font.Underline = XLFontUnderlineValues.Single;
                sheet1.Row(1).Style.Font.VerticalAlignment = XLFontVerticalTextAlignmentValues.Superscript;
                sheet1.Row(1).Style.Font.Italic = true;

                sheet1.RowHeight = 20;
                sheet1.Column(1).Width = 38;
                sheet1.Column(2).Width = 20;
                sheet1.Column(3).Width = 20;
                sheet1.Column(4).Width = 20;
                sheet1.Column(5).Width = 38;



                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return new ExcelReportResponse(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{request.FileName}.xlsx");

                }
            }
        }

        private async Task<DataTable> GetOrderAsync(CancellationToken cancellationToken = default)
        {
            var AllOrders = await _context.Orders.ToListAsync(cancellationToken);

            DataTable dt = new()
            {
                TableName = "Empdata"
            };
            dt.Columns.Add("Id", typeof(Guid));
            dt.Columns.Add("TotalPrice", typeof(decimal));
            dt.Columns.Add("CardPriceSum", typeof(decimal));
            dt.Columns.Add("CashPurchaseSum", typeof(decimal));
            dt.Columns.Add("ClientId", typeof(Guid));


            var _list = _mapper.Map<List<OrderResponse>>(AllOrders);
            if (_list.Count > 0)
            {
                _list.ForEach(item =>
                {
                    dt.Rows.Add(item.Id, item.TotalPrice, item.CardPriceSum, item.CashPurchaseSum, item.ClientId);

                });
            }

            return dt;
        }

    }
}

