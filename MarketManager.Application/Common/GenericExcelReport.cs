﻿using AutoMapper;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using MarketManager.Application.UseCases.Users.Report;
using MarketManager.Application.UseCases.Users.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.Common;
public class GenericExcelReport
{
    private readonly IMapper _mapper;

    public  GenericExcelReport(IMapper mapper)
    {
        _mapper = mapper;
    }

    public  async Task<ExcelReportResponse> GetReportExcel<T,TMAP>(string filename,List<T> data, CancellationToken cancellationToken)
    {
        using (XLWorkbook wb = new XLWorkbook())
        {
            var data2 = await GetDataAync<T,TMAP>(data);
            var sheet1 = wb.AddWorksheet(data2, nameof(T));


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
            sheet1.Column(5).Width = 20;
            sheet1.Column(6).Width = 20;
            sheet1.Column(7).Width = 20;
            sheet1.Column(8).Width = 20;
            sheet1.Column(9).Width = 20;



            using (MemoryStream ms = new MemoryStream())
            {
                wb.SaveAs(ms);
                return new ExcelReportResponse(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{filename}.xlsx");

            }
        }
    }

    private  async Task<DataTable> GetDataAync<T,TMAP>(List<T> data)
    {
      
        var properties = typeof(TMAP).GetProperties(); 


        DataTable dt = new DataTable();
        dt.TableName = typeof(T).Name;

        foreach (var property in properties)
        {
           dt.Columns.Add(property.Name,property.PropertyType);
        }
        
        var _list = _mapper.Map<List<TMAP>>(data);
        if (_list.Count > 0)
        {
            foreach (var item in _list)
            {
                DataRow row = dt.NewRow();
                foreach (var prop in item.GetType().GetProperties())
                {
                    row.SetField(prop.Name, prop.GetValue(item));
                }


                dt.Rows.Add(row);
            }
        }

        return await Task.FromResult(dt);
    }

}
