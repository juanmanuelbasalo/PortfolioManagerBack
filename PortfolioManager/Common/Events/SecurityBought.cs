using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class SecurityBought : IAuthenticatedEvent
    {
        public Guid SecurityId { get; }
        public Guid UserId { get; }
        public Guid PortfolioId { get; }
        public string Name { get; }
        public string Symbol { get; }
        public decimal CurrentValue { get; }
        public int Quantity { get; }

        public SecurityBought(Guid id, Guid userId, Guid portfolioId, string name, string symbol, decimal currentValue, int quantity)
        {
            SecurityId = id;
            UserId = userId;
            Name = name;
            Symbol = symbol;
            CurrentValue = currentValue;
            Quantity = quantity;
            PortfolioId = portfolioId;
        }
    }
}
