using AutoMapper;
using ClosedXML.Excel;
using MarketManager.Application.Common.Interfaces;
using MarketManager.Application.UseCases.Packages.Response;
using MarketManager.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using static MarketManager.Application.UseCases.Orders.Queries.GetAllOrders.GetallOrderCommmandHandler;

namespace MarketManager.Application.UseCases.Packages.Reports
{
    public record AddPackagesFromExcel(IFormFile ExcelFile) : IRequest<List<PackageResponse>>;

    public class AddPackagesFromExcelHandler : IRequestHandler<AddPackagesFromExcel, List<PackageResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddPackagesFromExcelHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PackageResponse>> Handle(AddPackagesFromExcel request, CancellationToken cancellationToken)
        {
            if (request.ExcelFile == null || request.ExcelFile.Length == 0)
                throw new ArgumentNullException("File", "file is empty or null");

            var file = request.ExcelFile;
            List<Package> result = new();

            using (var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms, cancellationToken);

                using (var wb = new XLWorkbook(ms))
                {
                    var sheet1 = wb.Worksheet(1);
                    int startRow = 2;

                    for (int row = startRow; row <= sheet1.LastRowUsed().RowNumber(); row++)
                    {
                        var package = new Package()
                        {
                            ProductId = Guid.Parse(sheet1.Cell(row, 1).GetString()),
                            IncomingCount= double.Parse(sheet1.Cell(row, 2).GetString()),
                            SupplierId = Guid.Parse(sheet1.Cell(row, 3).GetString()),
                            IncomingPrice = double.Parse(sheet1.Cell(row, 4).GetString()),
                            SalePrice = double.Parse(sheet1.Cell(row, 5).GetString()),
                            IncomingDate = DateTime.Parse(sheet1.Cell(row, 6).GetString())
                        };

                        result.Add(package);
                    }

                }
            }
            await _context.Packages.AddRangeAsync(result);
            await _context.SaveChangesAsync();

            return _mapper.Map<List<PackageResponse>>(result);
        }
    }
}