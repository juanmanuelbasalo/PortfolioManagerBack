using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class CreateUserRejected : IRejectedEvent
    {
        public string Email { get; set; }
        public string Reason { get; set; }

        public string Code { get; set; }

        public CreateUserRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
