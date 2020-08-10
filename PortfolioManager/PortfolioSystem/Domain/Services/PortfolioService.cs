using AutoMapper;
using Common.Commands;
using Common.Exceptions;
using Common.Repositories;
using PortfolioSystem.Data_Access.Entities;
using PortfolioSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Domain.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly ISqlServerRepository<Portfolio> repository;
        private readonly IMapper mapper;

        public PortfolioService(ISqlServerRepository<Portfolio> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task BuySecurityAsync(BuySecurity security)
        {
            if (security == null) throw new CustomException("empty_security", $"Security is empty.");

            var portfolio = await repository.FindAsync(p => p.UserId.Equals(security.UserId) && p.PortfolioId.Equals(security.PortfolioId));

            if (portfolio == null) throw new CustomException("portfolio_not_found", $"Portfolio not found for user: {security.UserId}");

            var securityEntity = portfolio.Securities.FirstOrDefault(i => i.Symbol.Equals(security.Symbol));

            if (securityEntity != null)
            {
                securityEntity.AverageValue = CalculateAverageValue(securityEntity.Quantity, securityEntity.AverageValue,
                                                                    security.Quantity, security.CurrentValue);
                securityEntity.Quantity += security.Quantity;
            }
            else
            {
                securityEntity = new Security
                {
                    Name = security.Name,
                    Symbol = security.Symbol,
                    CurrentValue = security.CurrentValue,
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
        private decimal CalculateAverageValue(int quantity1, decimal value1, int quantity2, decimal value2)
        {
            var totalQty = quantity1 + quantity2;
            var totalValue1 = quantity1 * value1;
            var totalValue2 = quantity2 * value2;

            var averageValue = (totalValue1 + totalValue2) / totalQty;
            return averageValue;
        }

        public async Task<PortfolioCreated> CreatePortfolioAsync(CreatePortfolio createPortfolio)
        {
            if (createPortfolio == null) throw new CustomException("empty_portfolio", $"Portfolio is empty.");

            var portfolio = mapper.Map<Portfolio>(createPortfolio);

            if (portfolio == null) return null;

            portfolio.CreatedAt = DateTimeOffset.UtcNow;
            portfolio.Securities = new List<Security>();

            repository.Insert(portfolio);
            var saved = await repository.SaveAsync();

            if (saved)
            {
                var portfolioCreated = mapper.Map<PortfolioCreated>(portfolio);
                return portfolioCreated;
            }

            throw new CustomException("problem_saving_portfolio", $"Could not save the portfolio: {portfolio.Name}.");
        }

    }
}
