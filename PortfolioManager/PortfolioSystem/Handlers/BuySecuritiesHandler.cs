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
    public class BuySecuritiesHandler : ICommandHandler<BuySecurity>
    {
        private readonly IPortfolioService portfolioService;
        private readonly IBusClient busClient;

        public BuySecuritiesHandler(IPortfolioService portfolioService, IBusClient busClient)
        {
            this.portfolioService = portfolioService;
            this.busClient = busClient;
        }
        public async Task HandleAsync(BuySecurity command)
        {
            try
            {
                await portfolioService.BuySecurityAsync(command);

                var securityBougt = new SecurityBought(command.SecurityId, command.UserId, command.PortfolioId, command.Name, 
                                                       command.Symbol, command.CurrentValue, command.Quantity);

                await busClient.PublishAsync(securityBougt);
            }
            catch (CustomException)
            {

            }
        }
    }
}
