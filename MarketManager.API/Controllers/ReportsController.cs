using MarketManager.Application.UseCases;
using MarketManager.Application.UseCases.ExpiredProducts.Report;
using MarketManager.Application.UseCases.Orders.Import.Export;
using MarketManager.Application.UseCases.Packages.Reports;
using MarketManager.Application.UseCases.Products.Reports;
using MarketManager.Application.UseCases.Users.Report;
using MarketManager.Application.UseCases.Users.Response;
using MarketManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

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
    public async Task<FileResult> TestUserGetExcelGeneric(string filename)
    {
        var result = await _mediator.Send(new TestUserGetExcel() { FileName = filename });
        return File(result.FileContents,result.Option, result.FileName);
        
    }

    [HttpGet("[action]")]
    public async Task<FileResult> ExportExcelExpiredProduct(string fileName = "expiredProduct")
    {
        var result = await _mediator.Send(new GetExpiredProductFromExcel { FileName = fileName });
        return File(result.FileContents, result.Option, result.FileName);
    }


    [HttpPost("[action]")]
    public async Task<List<ExpiredProduct>> ImportExcelExpiredProduct(IFormFile excelfile)
    {
        List<ExpiredProduct> result = await _mediator.Send(new AddExpiredProductFromExcel(excelfile));
        return result;
    }


}
