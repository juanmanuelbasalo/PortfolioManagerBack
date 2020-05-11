using Identity.Data_Access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Data_Access.SqlServer
{
    /// <summary>
    /// Represents my Identity Microservice database.
    /// </summary>
    public class IdentityContext : DbContext
    {
        /// <summary>
        /// Constructor for the context
        /// </summary>
        /// <param name="options">Passes the options/connection with the database.</param>
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        /// <summary>
        /// Represents the Users table from the database as a DbSet.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
