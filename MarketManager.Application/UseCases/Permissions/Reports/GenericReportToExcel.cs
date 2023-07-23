using AutoMapper;
using ClosedXML.Excel;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MarketManager.Application.UseCases.Permissions.Reports;
public record GenericReportToExcel : IRequest<MemoryStream>
{
    public string EndpoinName { get; set; }
}

public class GenericReportToExcelHandler : IRequestHandler<GenericReportToExcel, MemoryStream>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GenericReportToExcelHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MemoryStream> Handle(GenericReportToExcel request, CancellationToken cancellationToken)
    {
        var endpointName = request.EndpoinName;
        var dataTable = new DataTable();

        if (endpointName == "Users")
        {
            var entities = await _context.Users.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<User>(entities, cancellationToken);
        }
        else if (endpointName == "Products")
        {
            var entities = await _context.Products.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Product>(entities, cancellationToken);
        }
        else if (endpointName == "Permissions")
        {
            var entities = await _context.Permissions.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Permission>(entities, cancellationToken);
        }
        else if (endpointName == "Suppliers")
        {
            var entities = await _context.Suppliers.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Supplier>(entities, cancellationToken);
        }
        else if (endpointName == "Clients")
        {
            var entities = await _context.Clients.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Client>(entities, cancellationToken);
        }
        else if (endpointName == "ExpiredProducts")
        {
            var entities = await _context.ExpiredProducts.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<ExpiredProduct>(entities, cancellationToken);
        }
        else if (endpointName == "Roles")
        {
            var entities = await _context.Roles.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Role>(entities, cancellationToken);
        }
        else if (endpointName == "Packages")
        {
            var entities = await _context.Packages.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Package>(entities, cancellationToken);
        }
        else if (endpointName == "PaymentTypes")
        {
            var entities = await _context.PaymentTypes.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<PaymentType>(entities, cancellationToken);
        }
        else if (endpointName == "ProductTypes")
        {
            var entities = await _context.ProductTypes.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<ProductType>(entities, cancellationToken);
        }
        else if (endpointName == "Orders")
        {
            var entities = await _context.Orders.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Order>(entities, cancellationToken);
        }
        else if (endpointName == "Items")
        {
            var entities = await _context.Items.ToListAsync(cancellationToken);
            dataTable = await GetEntitiesAsync<Item>(entities, cancellationToken);
        }

        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dataTable);
            using (MemoryStream stream = new MemoryStream())
            {
                wb.SaveAs(stream);
                return stream;
            }
        }
    }

    private Task<DataTable> GetEntitiesAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default) where T : BaseEntity
    {
        DataTable dt = new DataTable();
        dt.TableName = typeof(T).Name + "Data";
        foreach (var property in typeof(T).GetProperties())
        {
            dt.Columns.Add(property.Name, property.PropertyType);
        }

        foreach (var entity in entities)
        {
            DataRow row = dt.NewRow();
            foreach (var property in typeof(T).GetProperties())
            {
                row[property.Name] = property.GetValue(entity);
            }
            dt.Rows.Add(row);
        }

        return Task.FromResult(dt);
    }
}


public record ExcelReportResponse(byte[] FileContents, string Option, string FileName);
