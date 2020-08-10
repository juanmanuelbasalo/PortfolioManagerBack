using Common.Commands;
using PortfolioSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Domain.Services
{
    public interface IPortfolioService
    {
        Task<PortfolioCreated> CreatePortfolioAsync(CreatePortfolio createPortfolio);
        Task BuySecurityAsync(BuySecurity security);
    }
}
