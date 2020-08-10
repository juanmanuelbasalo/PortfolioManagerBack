using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Commands
{
    public class BuySecurity : IAuthenticatedCommand
    {
        public Guid SecurityId { get; set; }
        public Guid UserId { get; set; }
        public Guid PortfolioId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal CurrentValue { get; set; }
        public int Quantity { get; set; }
    }
}
