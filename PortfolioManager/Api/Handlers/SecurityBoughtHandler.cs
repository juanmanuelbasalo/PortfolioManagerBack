using Api.Domain.Services;
using Common.Events;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Handlers
{
    public class SecurityBoughtHandler : IEventHandler<SecurityBought>
    {
        private readonly IPortfolioService service;

        public SecurityBoughtHandler(IPortfolioService service)
        {
            this.service = service;
        }
        public async Task HandleAsync(SecurityBought @event)
        {
            if (@event == null) throw new CustomException("securityBought_event_empty", "Could not buy the security.");

            await service.BuySecuritiesAsync(@event);
        }
    }
}
