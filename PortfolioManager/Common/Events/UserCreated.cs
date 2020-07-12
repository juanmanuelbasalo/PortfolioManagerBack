using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; }
        public string Name { get; }
        public string UserName { get; set; }
        public DateTimeOffset LastActive { get; set; }
        public UserCreated(string email, string name, string userName, DateTimeOffset lastActive)
        {
            Email = email;
            Name = name;
            UserName = userName;
            LastActive = lastActive;
        }
    }
}
