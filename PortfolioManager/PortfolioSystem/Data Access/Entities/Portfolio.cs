using System;
using System.Collections.Generic;

namespace PortfolioSystem.Data_Access.Entities
{
    public class Portfolio
    {
        public Guid PortfolioId { get; set; }
        public decimal LiquidationValue { get; set; }
        public decimal ProfitAndLoss { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public ICollection<Security> Securities { get; set; }
    }
}
