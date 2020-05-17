using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; }
        public string Name { get; }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
