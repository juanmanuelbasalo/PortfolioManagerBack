using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Security
    {
        public Guid SecurityId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal AverageValue { get; set; }
        public int Quantity { get; set; }
        public Portfolio Portfolio { get; set; }
        public Guid PortfolioId { get; set; }
    }
}
