using Api.Domain.Models;
using Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Services
{
    public interface IPortfolioService
    {
        Task CreateNewPortfolioAsync(Portfolio portfolio);
        Task BuySecuritiesAsync(SecurityBought security);
    }
}
