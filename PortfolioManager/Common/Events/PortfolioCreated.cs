using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class PortfolioCreated : IAuthenticatedEvent
    {
        public string UserName { get; }
        public Guid PortfolioId { get; }
        public decimal LiquidationValue { get; }
        public decimal ProfitAndLoss { get; }
        public string Name { get; }
        public DateTimeOffset CreatedAt { get; }

        public PortfolioCreated(string UserName, Guid PortfolioId, decimal LiquidationValue, decimal ProfitAndLoss,
            string Name, DateTimeOffset CreatedAt)
        {
            this.UserName = UserName;
            this.PortfolioId = PortfolioId;
            this.LiquidationValue = LiquidationValue;
            this.ProfitAndLoss = ProfitAndLoss;
            this.Name = Name;
            this.CreatedAt = CreatedAt;
        }
    }
}
