using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Domain.Events
{
    public class PriceChangedEventArgs : EventArgs
    {
        public decimal LastPrice { get; }
        public decimal NewPrice { get; }

        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }
}
