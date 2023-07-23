using MarketManager.Application.UseCases.Orders.Import.Export;
using MarketManager.Application.UseCases.Users.Report;
using MarketManager.Application.UseCases.Users.Response;
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
    public async Task<FileResult> ExportExcelOrders(string fileName = "orders")
    {
        var result = await _mediator.Send(new GetOrderExcel { FileName = fileName });
        return File(result.FileContents, result.Option, result.FileName);
    }


    [HttpPost("[action]")]
    public async Task<List<OrderResponse>> ImportExcelOrders(IFormFile excelfile)
    {
        var result = await _mediator.Send(new AddOrdersFromExcel(excelfile));
        return result;
    }


    [HttpGet("[action]")]
    public async Task<FileResult> ExportPdfOrders(string fileName = "orders")
    {
        var result = await _mediator.Send(new GetOrderPDF(fileName));
        return File(result.FileContents, result.Options, result.FileName);
    }



}
