using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Models
{
    public class Portfolio
    {
        public Guid PortfolioId { get; set; }
        public decimal LiquidationValue { get; set; }
        public decimal ProfitAndLoss { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
