using ClosedXML.Excel;
using MarketManager.Application.UseCases.Users.Queries.GetAllUser;
using MarketManager.Application.UseCases.Users.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Drawing;
using System.Net;

namespace MarketManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportsController : BaseApiController
{
  
    [HttpPost]
    public async Task<FileResult> ExportExcel(string fileName = "users")
    {
       
        using (XLWorkbook wb = new XLWorkbook())
        {
            var userData =await GetUsersAsync();
            var sheet1 = wb.AddWorksheet(userData, "Users");
    

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
            
          

            using (MemoryStream ms = new MemoryStream())
            {
                wb.SaveAs(ms);
                return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{fileName}.xlsx");
            }
        }
    }
    [NonAction]
    private async Task<DataTable> GetUsersAsync()
    {
        DataTable dt = new DataTable();
        dt.TableName = "Empdata";
        dt.Columns.Add("Code", typeof(Guid));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Username", typeof(string));
        dt.Columns.Add("Phone", typeof(string));
        

        var _list =await _mediator.Send(new GetAllUserQuery());
        if (_list.Count > 0)
        {
            _list.ForEach(item =>
            {
                dt.Rows.Add(item.Id, item.FullName, item.Username, item.Phone);
               
            });
        }

        return await Task.FromResult(dt);
    }

}
