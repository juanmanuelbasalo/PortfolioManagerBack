using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data_Access.Entities
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Date and time of user's creation.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>
        /// Who created the user. The system by default.
        /// </summary>
        public string CreatedBy { get; set; }
        public DateTimeOffset LastActive { get; set; }
    }
}
