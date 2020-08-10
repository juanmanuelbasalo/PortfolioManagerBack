using Api.Domain.Models;
using Common.Events;
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

        public async Task BuySecuritiesAsync(SecurityBought security)
        {
            if (security == null) throw new CustomException("empty_security", "There was a problem with this security, please contact support.");

            var portfolio = await repository.FindAsync(p => p.UserId.Equals(security.UserId) && p.PortfolioId.Equals(security.PortfolioId));

            if (portfolio == null) throw new CustomException("portfolio_not_found", $"Portfolio not found for user: {security.UserId}");

            var securityEntity = portfolio.Securities.FirstOrDefault(i => i.Symbol.Equals(security.Symbol));

            if (securityEntity != null)
            {
                securityEntity.AverageValue = security.CurrentValue;
                securityEntity.Quantity = security.Quantity;
            }
            else
            {
                securityEntity = new Security
                {
                    Name = security.Name,
                    Symbol = security.Symbol,
                    AverageValue = security.CurrentValue,
                    Quantity = security.Quantity,
                };
            }

            portfolio.Securities.Add(securityEntity);
            var saved = await repository.SaveAsync();

            if (!saved)
            {
                throw new CustomException("problem_buying_securities", $"Could not buy the security: {security.Symbol}.");
            }
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
