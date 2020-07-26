using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class LoggedInUser
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Name of the user.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// User's email.
        /// </summary>
        public string Email { get; set; }
        public string UserName { get; set; }
        /// <summary>
        /// User claims
        /// </summary>
        public ICollection<Claim> Claims { get; set; }
    }
}
