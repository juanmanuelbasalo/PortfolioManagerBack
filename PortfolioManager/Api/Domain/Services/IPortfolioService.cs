using Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Services
{
    public interface IPortfolioService
    {
        Task CreateNewPortfolioAsync(Portfolio portfolio);
    }
}
