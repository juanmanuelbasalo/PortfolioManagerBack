using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Commands
{
    public class CreatePortfolio : IAuthenticatedCommand
    {
        public Guid PortfolioId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
