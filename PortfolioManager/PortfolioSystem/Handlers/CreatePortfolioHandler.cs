using Common.Commands;
using Common.Events;
using Common.Exceptions;
using PortfolioSystem.Domain.Services;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSystem.Handlers
{
    public class CreatePortfolioHandler : ICommandHandler<CreatePortfolio>
    {
        private readonly IBusClient busClient;
        private readonly IPortfolioService portfolioService;

        public CreatePortfolioHandler(IBusClient busClient, IPortfolioService portfolioService)
        {
            this.busClient = busClient;
            this.portfolioService = portfolioService;
        }

        public async Task HandleAsync(CreatePortfolio command)
        {
            try
            {
                var portfolioCreated = await portfolioService.CreatePortfolioAsync(command);

                if (portfolioCreated == null)
                {
                    await busClient.PublishAsync(new CreatePortfolioRejected(command.UserId, command.Name, "Problem resolving the portfolio.", "400"));
                }
                else
                {
                    await busClient.PublishAsync(new PortfolioCreated(portfolioCreated.UserId, portfolioCreated.PortfolioId,
                        portfolioCreated.LiquidationValue, portfolioCreated.ProfitAndLoss, portfolioCreated.Name, portfolioCreated.CreatedAt));
                }
            }
            catch (CustomException ex)
            {
                await busClient.PublishAsync(new CreatePortfolioRejected(command.UserId, command.Name, "Problem saving portfolio.", ex.Code));

            }
        }
    }
}
