using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Commands
{
    public class CreatePortfolio : IAuthenticatedCommand
    {
        public Guid PortfolioId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
