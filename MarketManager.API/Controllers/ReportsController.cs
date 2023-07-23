using MarketManager.Application.UseCases.Orders.Import.Export;
using MarketManager.Application.UseCases.Products;
using MarketManager.Application.UseCases.Users.Report;
using MarketManager.Application.UseCases.Users.Response;
using Microsoft.AspNetCore.Mvc;

namespace MarketManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportsController : BaseApiController
{

    [HttpGet("[action]")]
    public async Task<FileResult> ExportExcelUsers(string fileName = "users")
    {
       var result = await _mediator.Send(new GetUsersExcel { FileName = fileName });
        return File(result.FileContents, result.Option, result.FileName);
    }


    [HttpPost("[action]")]
    public async Task<List<UserResponse>> ImportExcelUsers(IFormFile excelfile)
    {
        var result = await _mediator.Send(new AddUsersFromExcel(excelfile));
        return result;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> ExportExcelUserByTelegram(string userId, string fileName = "users")
    {
        await _mediator.Send(new GetUsersExcelByTelegram(userId, fileName));
        return Ok();
    }



    [HttpGet("[action]")] 
    public async Task<FileResult> TestExcel(string filename)
    {
        var result = await _mediator.Send(new TestGetExcel() { FileName = filename });
        return File(result.FileContents,result.Option, result.FileName);
        
    }


    [HttpGet("[action]")]
    public async Task<FileResult> ExportExcelOrders(string fileName = "orders")
    {
        var result = await _mediator.Send(new GetOrderExcel { FileName = fileName });
        return File(result.FileContents, result.Option, result.FileName);
    }




}
