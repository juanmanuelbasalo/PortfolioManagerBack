using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class CreatePortfolioRejected : IAuthenticatedEvent
    {
        public string UserName { get; }
        public string Name { get; set; }
        public string Reason { get; }
        public string Code { get; }

        public CreatePortfolioRejected(string userName, string name, string reason, string code)
        {
            UserName = userName;
            Name = name;
            Reason = reason;
            Code = code;
        }
    }
}
