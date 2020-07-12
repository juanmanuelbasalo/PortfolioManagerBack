using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Data_Access.Entities
{
    public class Portfolio
    {
        public Guid PortfolioId { get; set; }
        public decimal LiquidationValue { get; set; }
        public decimal ProfitAndLoss { get; set; }
        public string Name { get; set; }
        public ICollection<Security> Securities { get; set; }
    }
}
