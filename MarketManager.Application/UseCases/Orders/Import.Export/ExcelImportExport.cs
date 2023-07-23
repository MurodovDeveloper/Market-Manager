using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Orders.Import.Export
{
    public class ExcelImportExport
    {
        public static void ReadingData()
        {
            using (var package = new ExcelPackage(new FileInfo(@"C:\Users\jturs\Desktop\file.xlsx")))
            {
                var worksheet = package.Workbook.Worksheets[0];

                string valueA1 = worksheet.Cells["A1"].Value?.ToString();
                string valueB2 = worksheet.Cells["B2"].Value?.ToString();

                Console.WriteLine("{0}     {1}", valueB2, valueA1);
            }

        }

        public static void SendData()
        {

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                worksheet.Cells["A1"].Value = "Hello";
                worksheet.Cells["B2"].Value = "World";


                
                package.SaveAs(new FileInfo(@"C:\Users\jturs\Desktop\file.xlsx"));
            }



        }
    }
}
