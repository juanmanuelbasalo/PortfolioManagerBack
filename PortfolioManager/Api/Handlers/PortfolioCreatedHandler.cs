using Api.Domain.Models;
using Api.Domain.Services;
using AutoMapper;
using Common.Events;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Handlers
{
    public class PortfolioCreatedHandler : IEventHandler<PortfolioCreated>
    {
        private readonly IPortfolioService portfolioService;
        private readonly IMapper mapper;

        public PortfolioCreatedHandler(IPortfolioService portfolioService, IMapper mapper)
        {
            this.portfolioService = portfolioService;
            this.mapper = mapper;
        }

        public async Task HandleAsync(PortfolioCreated @event)
        {
            if (@event == null) throw new CustomException("portfolio_event_empty", "Could not create the portfolio.");

            var portfolio = mapper.Map<Portfolio>(@event);
            await portfolioService.CreateNewPortfolioAsync(portfolio);
        }
    }
}
