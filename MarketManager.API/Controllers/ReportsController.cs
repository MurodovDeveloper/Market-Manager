using ClosedXML.Excel;
using MarketManager.Application.UseCases.Users.Queries.GetAllUser;
using MarketManager.Application.UseCases.Users.Report;
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
       var result = await _mediator.Send(new GetUsersExcel { FileName = fileName });
        return File(result.FileContents, result.Option, result.FileName);
    }
    
   
}
