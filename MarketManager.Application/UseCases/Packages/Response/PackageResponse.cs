using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Application.UseCases.Packages.Response
{
    public class PackageResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double IncomingCount { get; set; }
        public double Count { get; set; }
        public Guid SupplierId { get; set; }
        public double IncomingPrice { get; set; }
        public double SalePrice { get; set; }

        public DateTime IncomingDate { get; set; }
    }
}
