using Api.Domain.Models;
using Common.Exceptions;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly ISqlServerRepository<Portfolio> repository;

        public PortfolioService(ISqlServerRepository<Portfolio> repository)
        {
            this.repository = repository;
        }

        public async Task CreateNewPortfolioAsync(Portfolio portfolio)
        {
            if (portfolio == null) throw new CustomException("empty_portfolio", "There was a problem with this portfolio, please contact support.");

            repository.Insert(portfolio);
            var saved = await repository.SaveAsync();

            if (!saved)
            {
                throw new CustomException("problem_saving_portfolio", "There was a problem saving the portfolio, try latter.");
            }
        }
    }
}
