using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class CreatePortfolioRejected : IAuthenticatedEvent, IRejectedEvent
    {
        public Guid UserId { get; }
        public string Name { get; }
        public string Reason { get; }
        public string Code { get; }

        public CreatePortfolioRejected(Guid UserId, string name, string reason, string code)
        {
            UserId = UserId;
            Name = name;
            Reason = reason;
            Code = code;
        }
    }
}
