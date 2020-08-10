using PortfolioSystem.Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Domain.Models
{
    public class PortfolioCreated
    {
        public Guid PortfolioId { get; set; }
        public decimal LiquidationValue { get; set; }
        public decimal ProfitAndLoss { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
