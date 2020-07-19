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
        public Task BuySecurity()
        {
            throw new NotImplementedException();
        }

        public async Task<PortfolioCreated> CreatePortfolioAsync(CreatePortfolio createPortfolio)
        {
            if (createPortfolio == null) throw new CustomException("empty_portfolio", $"Portfolio is empty.");

            var portfolio = mapper.Map<Portfolio>(createPortfolio);

            if (portfolio == null) return null;

            portfolio.PortfolioId = Guid.NewGuid();
            portfolio.CreatedAt = DateTimeOffset.UtcNow;

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
