using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MarketManager.Application.Common.Interfaces;
using MediatR;

namespace MarketManager.Application.UseCases.Orders.Import.Export;

public record GetOrderPDF(string FileName) : IRequest<PDFExportResponse>;

public class GetOrderPDFHandler : IRequestHandler<GetOrderPDF, PDFExportResponse>
{

    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderPDFHandler(IApplicationDbContext context, IMapper mapper)
    {

        _context = context;
        _mapper = mapper;
    }

    public async Task<PDFExportResponse> Handle(GetOrderPDF request, CancellationToken cancellationToken)
    {

        using (MemoryStream ms = new MemoryStream())
        {
            Document document = new Document();

            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            document.Open();

            PdfPTable table = new PdfPTable(5);

            table.SetWidths(new float[] { 2f, 0.5f, 0.5f, 0.5f, 2f });

            // Add table headers
            table.AddCell("ID");
            table.AddCell("Total Price");
            table.AddCell("Card Price Sum");
            table.AddCell("CashPurchaseSum");
            table.AddCell("Client ID");

            foreach (var order in _context.Orders)
            {
                table.AddCell(order.Id.ToString());
                table.AddCell($"{order.TotalPrice}");
                table.AddCell(order.CardPriceSum.ToString());
                table.AddCell(order.CashPurchaseSum.ToString());
                table.AddCell(order.ClientId.ToString());
            }

            document.Add(table);

            return new PDFExportResponse(ms.ToArray(), "application/pdf", request.FileName);
        }
    }

}

public record PDFExportResponse(byte[] FileContents , string Options, string FileName);
