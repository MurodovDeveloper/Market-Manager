using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;

namespace MarketManager.Application.UseCases.Orders.Import.Export;

internal class GetOrderPDF
{
    public static void ImportData()
    {
        using (var stream = new FileStream(@"C:\Users\jturs\Desktop\IeltsResult.pdf", FileMode.Create))
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, stream);

            document.Open();

            document.Add(new Paragraph("Hello, World!"));

            document.Close();
        }
    }


    public static void ExportData() {

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            worksheet.Cells["A1"].Value = "Hello";
            worksheet.Cells["B2"].Value = "World";
            
            package.SaveAs(new FileInfo("path/to/new/excel/file.xlsx"));
        }
    }
}
